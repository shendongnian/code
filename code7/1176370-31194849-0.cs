    public class AlwaysAllowUInt32OverflowConvention : IMemberMapConvention
    {
        public string Name
        {
            get { return "AlwaysAllowUInt32Overflow"; }
        }
        public void Apply(BsonMemberMap memberMap)
        {
            if (memberMap.MemberType == typeof(UInt32))
            {
                var uint32Serializer = new UInt32Serializer(BsonType.Int32, new RepresentationConverter(true, true));
                memberMap.SetSerializer(uint32Serializer);
            }
        }
    }
