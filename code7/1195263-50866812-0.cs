    public class CustomEnumSerializer<TEnum> : StructSerializerBase<TEnum>, IRepresentationConfigurable<CustomEnumSerializer<TEnum>> where TEnum : struct
    {
        private static Dictionary<Type, Dictionary<string, object>> _fromValueMap; // string representation to Enum value map
        private static Dictionary<Type, Dictionary<object, string>> _toValueMap; // Enum value to string map
        // private fields
        private readonly BsonType _representation;
        // constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumSerializer{TEnum}"/> class.
        /// </summary>
        public CustomEnumSerializer()
            : this((BsonType)0) // 0 means use underlying type
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumSerializer{TEnum}"/> class.
        /// </summary>
        /// <param name="representation">The representation.</param>
        public CustomEnumSerializer(BsonType representation)
        {
            switch (representation)
            {
                case 0:
                case BsonType.Int32:
                case BsonType.Int64:
                case BsonType.String:
                    break;
                default:
                    var message = string.Format("{0} is not a valid representation for an EnumSerializer.", representation);
                    throw new ArgumentException(message);
            }
            // don't know of a way to enforce this at compile time
            var enumTypeInfo = typeof(TEnum).GetTypeInfo();
            if (!enumTypeInfo.IsEnum)
            {
                var message = string.Format("{0} is not an enum type.", typeof(TEnum).FullName);
                throw new BsonSerializationException(message);
            }
            _representation = representation;
            if (representation == BsonType.String)
            {
                if (_fromValueMap == null)
                    _fromValueMap = new Dictionary<Type, Dictionary<string, object>>();
                if (_toValueMap == null)
                    _toValueMap = new Dictionary<Type, Dictionary<object, string>>();
                var enumType = typeof(TEnum);
                if (!_fromValueMap.ContainsKey(enumType))
                {
                    Dictionary<string, object> fromMap = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
                    Dictionary<object, string> toMap = new Dictionary<object, string>();
                    FieldInfo[] fields = enumType.GetFields(BindingFlags.Static | BindingFlags.Public);
                    foreach (FieldInfo field in fields)
                    {
                        string name = field.Name;
                        object enumValue = Enum.Parse(enumType, name);
                        // use EnumMember attribute if exists
                        EnumMemberAttribute enumMemberAttrbiute = field.GetCustomAttribute<EnumMemberAttribute>();
                        if (enumMemberAttrbiute != null)
                        {
                            string enumMemberValue = enumMemberAttrbiute.Value;
                            fromMap[enumMemberValue] = enumValue;
                            toMap[enumValue] = enumMemberValue;
                        }
                        else
                        {
                            toMap[enumValue] = name;
                        }
                        fromMap[name] = enumValue;
                    }
                    _fromValueMap[enumType] = fromMap;
                    _toValueMap[enumType] = toMap;
                }
            }
        }
        // public properties
        /// <summary>
        /// Gets the representation.
        /// </summary>
        /// <value>
        /// The representation.
        /// </value>
        public BsonType Representation
        {
            get { return _representation; }
        }
        // public methods
        /// <summary>
        /// Deserializes a value.
        /// </summary>
        /// <param name="context">The deserialization context.</param>
        /// <param name="args">The deserialization args.</param>
        /// <returns>A deserialized value.</returns>
        public override TEnum Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var bsonReader = context.Reader;
            var bsonType = bsonReader.GetCurrentBsonType();
            switch (bsonType)
            {
                case BsonType.Int32: return (TEnum)Enum.ToObject(typeof(TEnum), bsonReader.ReadInt32());
                case BsonType.Int64: return (TEnum)Enum.ToObject(typeof(TEnum), bsonReader.ReadInt64());
                case BsonType.Double: return (TEnum)Enum.ToObject(typeof(TEnum), (long)bsonReader.ReadDouble());
                case BsonType.String:
                    var readerValue = bsonReader.ReadString();
                    var fromValue = FromValue(typeof(TEnum), readerValue);
                    var fromValueAsString = fromValue.ToString();
                    if ((fromValue as string) == null)
                    {
                        var a = 1;
                    }
                    return (TEnum)Enum.Parse(typeof(TEnum), fromValueAsString);
                default:
                    throw CreateCannotDeserializeFromBsonTypeException(bsonType);
            }
        }
        /// <summary>
        /// Serializes a value.
        /// </summary>
        /// <param name="context">The serialization context.</param>
        /// <param name="args">The serialization args.</param>
        /// <param name="value">The object.</param>
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, TEnum value)
        {
            var bsonWriter = context.Writer;
            switch (_representation)
            {
                case 0:
                    var underlyingTypeCode = Type.GetTypeCode(Enum.GetUnderlyingType(typeof(TEnum)));
                    if (underlyingTypeCode == TypeCode.Int64 || underlyingTypeCode == TypeCode.UInt64)
                    {
                        goto case BsonType.Int64;
                    }
                    else
                    {
                        goto case BsonType.Int32;
                    }
                case BsonType.Int32:
                    bsonWriter.WriteInt32(Convert.ToInt32(value));
                    break;
                case BsonType.Int64:
                    bsonWriter.WriteInt64(Convert.ToInt64(value));
                    break;
                case BsonType.String:
                    var val = ToValue(typeof(TEnum), value);
                    bsonWriter.WriteString(val);
                    break;
                default:
                    throw new BsonInternalException("Unexpected EnumRepresentation.");
            }
        }
        private string ToValue(Type enumType, object obj)
        {
            Dictionary<object, string> map = _toValueMap[enumType];
            return map[obj];
        }
        private object FromValue(Type enumType, string value)
        {
            Dictionary<string, object> map = _fromValueMap[enumType];
            if (!map.ContainsKey(value))
                return value;
            return map[value];
        }
        /// <summary>
        /// Returns a serializer that has been reconfigured with the specified representation.
        /// </summary>
        /// <param name="representation">The representation.</param>
        /// <returns>The reconfigured serializer.</returns>
        public CustomEnumSerializer<TEnum> WithRepresentation(BsonType representation)
        {
            if (representation == _representation)
            {
                return this;
            }
            else
            {
                return new CustomEnumSerializer<TEnum>(representation);
            }
        }
        // explicit interface implementations
        IBsonSerializer IRepresentationConfigurable.WithRepresentation(BsonType representation)
        {
            return WithRepresentation(representation);
        }
    }
