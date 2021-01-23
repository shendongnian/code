    /// <summary>
    /// Creates types that are much like anonymous types.
    /// </summary>
    public static class TupleFactory
    {
        // the dynamic module used to emit new types
        private static readonly ModuleBuilder _module = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName { Name = nameof(TupleFactory) }, AssemblyBuilderAccess.Run).DefineDynamicModule(nameof(TupleFactory), false);
        // the generic type definitions constructed so far
        private static readonly Dictionary<ICollection<string>, Type> _genericTypeDefinitions = new Dictionary<ICollection<string>, Type>(CollectionComparer<string>.Default);
        // the new expression factory singletons constructed so far
        private static readonly Dictionary<ICollection<KeyValuePair<string, Type>>, ITupleFactory> _newExpressionFactories = new Dictionary<ICollection<KeyValuePair<string, Type>>, ITupleFactory>(new CollectionComparer<KeyValuePair<string, Type>>(KeyValueComparer<string, Type>.Default));
        // some reflection objects used
        private static readonly ConstructorInfo _objectCtor = typeof(object).GetConstructor(Type.EmptyTypes);
        private static readonly MethodInfo _objectEquals = typeof(object).GetMethod("Equals", BindingFlags.Public | BindingFlags.Instance, null, new[] { typeof(object) }, null);
        private static readonly MethodInfo _objectGetHashCode = typeof(object).GetMethod("GetHashCode", BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null);
        private static readonly MethodInfo _objectToString = typeof(object).GetMethod("ToString", BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null);
        private static readonly MethodInfo _stringFormat = typeof(string).GetMethod("Format", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(string), typeof(object[]) }, null);
        private static readonly MethodInfo _equalityComparerDefaultGetter;
        private static readonly MethodInfo _equalityComparerEquals;
        private static readonly MethodInfo _equalityComparerGetHashCode;
        static TupleFactory()
        {
            // init more reflection objects
            _equalityComparerDefaultGetter = typeof(EqualityComparer<>).GetProperty("Default", BindingFlags.Public | BindingFlags.Static).GetGetMethod();
            var eqT = typeof(EqualityComparer<>).GetGenericArguments()[0];
            _equalityComparerEquals = typeof(EqualityComparer<>).GetMethod("Equals", BindingFlags.Public | BindingFlags.Instance, null, new[] { eqT, eqT }, null);
            _equalityComparerGetHashCode = typeof(EqualityComparer<>).GetMethod("GetHashCode", BindingFlags.Public | BindingFlags.Instance, null, new[] { eqT }, null);
        }
        /// <summary>
        /// Gets a <see cref="ITupleFactory"/> singleton for a sequence of properties.
        /// </summary>
        /// <param name="properties">Name/Type pairs for the properties.</param>
        public static ITupleFactory Create(IEnumerable<KeyValuePair<string, Type>> properties)
        {
            // check input
            if (properties == null) throw new ArgumentNullException(nameof(properties));
            var propList = properties.ToList();
            if (propList.Select(p => p.Key).Distinct().Count() != propList.Count)
                throw new ArgumentException("Property names must be distinct.");
            lock (_module) // locks access to the static dictionaries
            {
                ITupleFactory result;
                if (_newExpressionFactories.TryGetValue(propList, out result)) // we already have it
                    return result;
                var propertyNames = propList.Select(p => p.Key).ToList();
                Type genericTypeDefinition;
                if (!_genericTypeDefinitions.TryGetValue(propertyNames, out genericTypeDefinition))
                {
                    #region create new generic type definition
                    {
                        var typeBuilder = _module.DefineType($"<>f__AnonymousType{_newExpressionFactories.Count}`{propertyNames.Count}", TypeAttributes.Public | TypeAttributes.AutoClass | TypeAttributes.AnsiClass | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit);
                        var genParams = propertyNames.Count > 0
                            ? typeBuilder.DefineGenericParameters(propertyNames.Select(p => $"<{p}>j__TPar").ToArray())
                            : new GenericTypeParameterBuilder[0];
                        // attributes on type
                        var debuggerDisplay = "\\{ " + string.Join(", ", propertyNames.Select(n => $"{n} = {{{n}}}")) + " }";
                        // ReSharper disable AssignNullToNotNullAttribute
                        typeBuilder.SetCustomAttribute(new CustomAttributeBuilder(typeof(DebuggerDisplayAttribute).GetConstructor(new[] { typeof(string) }), new object[] { debuggerDisplay }));
                        typeBuilder.SetCustomAttribute(new CustomAttributeBuilder(typeof(CompilerGeneratedAttribute).GetConstructor(Type.EmptyTypes), new object[0]));
                        // ReSharper restore AssignNullToNotNullAttribute
                        var fields = new List<FieldBuilder>();
                        var props = new List<PropertyBuilder>();
                        foreach (var name in propertyNames)
                        {
                            var genParam = genParams[fields.Count];
                            var field = typeBuilder.DefineField($"<{name}>i__Field", genParam, FieldAttributes.Private | FieldAttributes.InitOnly);
                            fields.Add(field);
                            var property = typeBuilder.DefineProperty(name, PropertyAttributes.None, genParam, null);
                            props.Add(property);
                            var getter = typeBuilder.DefineMethod($"get_{name}", MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, genParam, Type.EmptyTypes);
                            var il = getter.GetILGenerator();
                            il.Emit(OpCodes.Ldarg_0);
                            il.Emit(OpCodes.Ldfld, field);
                            il.Emit(OpCodes.Ret);
                            property.SetGetMethod(getter);
                        }
                        #region ctor
                        {
                            // ReSharper disable once CoVariantArrayConversion
                            var ctorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, genParams);
                            var il = ctorBuilder.GetILGenerator();
                            // call base class ctor
                            il.Emit(OpCodes.Ldarg_0);
                            il.Emit(OpCodes.Call, _objectCtor);
                            // assign args to fields
                            for (var i = 0; i < fields.Count; i++)
                            {
                                il.Emit(OpCodes.Ldarg_0);
                                EmitLdarg(il, i + 1);
                                il.Emit(OpCodes.Stfld, fields[i]);
                            }
                            il.Emit(OpCodes.Ret);
                        }
                        #endregion
                        #region override Equals
                        {
                            var equals = typeBuilder.DefineMethod("Equals", MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.Virtual, typeof(bool), new[] { typeof(object) });
                            typeBuilder.DefineMethodOverride(equals, _objectEquals);
                            var il = equals.GetILGenerator();
                            il.DeclareLocal(typeBuilder);
                            var retFalse = il.DefineLabel();
                            var ret = il.DefineLabel();
                            // local = argument as (the type being constructed)?
                            il.Emit(OpCodes.Ldarg_1);
                            il.Emit(OpCodes.Isinst, typeBuilder);
                            il.Emit(OpCodes.Stloc_0);
                            // push result of the "as" operator
                            il.Emit(OpCodes.Ldloc_0);
                            foreach (var field in fields)
                            {
                                var comparer = typeof(EqualityComparer<>).MakeGenericType(field.FieldType);
                                var defaultGetter = TypeBuilder.GetMethod(comparer, _equalityComparerDefaultGetter);
                                var equalsMethod = TypeBuilder.GetMethod(comparer, _equalityComparerEquals);
                                // check if the result of the previous check is false
                                il.Emit(OpCodes.Brfalse, retFalse);
                                // push EqualityComparer<FieldType>.Default.Equals(this.field, other.field)
                                il.Emit(OpCodes.Call, defaultGetter);
                                il.Emit(OpCodes.Ldarg_0);
                                il.Emit(OpCodes.Ldfld, field);
                                il.Emit(OpCodes.Ldloc_0);
                                il.Emit(OpCodes.Ldfld, field);
                                il.Emit(OpCodes.Callvirt, equalsMethod);
                            }
                            // jump to the end with what was the last result
                            il.Emit(OpCodes.Br_S, ret);
                            // push false
                            il.MarkLabel(retFalse);
                            il.Emit(OpCodes.Ldc_I4_0);
                            il.MarkLabel(ret);
                            il.Emit(OpCodes.Ret);
                        }
                        #endregion
                        #region override GetHashCode
                        {
                            var getHashCode = typeBuilder.DefineMethod("GetHashCode", MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.Virtual, typeof(int), Type.EmptyTypes);
                            typeBuilder.DefineMethodOverride(getHashCode, _objectGetHashCode);
                            var il = getHashCode.GetILGenerator();
                            // init result with seed
                            il.Emit(OpCodes.Ldc_I4, HashCode.Seed);
                            foreach (var field in fields)
                            {
                                var comparer = typeof(EqualityComparer<>).MakeGenericType(field.FieldType);
                                var defaultGetter = TypeBuilder.GetMethod(comparer, _equalityComparerDefaultGetter);
                                var getHashCodeMethod = TypeBuilder.GetMethod(comparer, _equalityComparerGetHashCode);
                                // hash so far * factor
                                il.Emit(OpCodes.Ldc_I4, HashCode.Factor);
                                il.Emit(OpCodes.Mul);
                                // ... + EqualityComparer<FieldType>.GetHashCode(field)
                                il.Emit(OpCodes.Call, defaultGetter);
                                il.Emit(OpCodes.Ldarg_0);
                                il.Emit(OpCodes.Ldfld, field);
                                il.Emit(OpCodes.Callvirt, getHashCodeMethod);
                                il.Emit(OpCodes.Add);
                            }
                            il.Emit(OpCodes.Ret);
                        }
                        #endregion
                        #region override ToString
                        {
                            var toString = typeBuilder.DefineMethod("ToString", MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.Virtual, typeof(string), Type.EmptyTypes);
                            typeBuilder.DefineMethodOverride(toString, _objectToString);
                            var template = "{{ " + string.Join(", ", propertyNames.Select((n, i) => $"{n} = {{{i}}}")) + " }}";
                            var il = toString.GetILGenerator();
                            // push template
                            il.Emit(OpCodes.Ldstr, template);
                            // push new array
                            EmitLdc(il, fields.Count);
                            il.Emit(OpCodes.Newarr, typeof(object));
                            var index = 0;
                            foreach (var field in fields)
                            {
                                il.Emit(OpCodes.Dup); // duplicate array ref
                                EmitLdc(il, index); // push array index
                                // store boxed field in array
                                il.Emit(OpCodes.Ldarg_0);
                                il.Emit(OpCodes.Ldfld, field);
                                il.Emit(OpCodes.Box, field.FieldType);
                                il.Emit(OpCodes.Stelem, typeof(object));
                                index++;
                            }
                            il.Emit(OpCodes.Call, _stringFormat);
                            il.Emit(OpCodes.Ret);
                        }
                        #endregion
                        genericTypeDefinition = typeBuilder.CreateType();
                    }
                    #endregion
                    _genericTypeDefinitions.Add(propertyNames, genericTypeDefinition);
                }
                var type = propList.Count == 0 ? genericTypeDefinition : genericTypeDefinition.MakeGenericType(propList.Select(p => p.Value).ToArray());
                result = new TupleFactoryImpl(type, propertyNames);
                _newExpressionFactories.Add(propList, result);
                return result;
            }
        }
        /// <summary>
        /// Gets a <see cref="NewExpression"/> for a tuple type with the specified properties.
        /// </summary>
        public static NewExpression MakeNewExpression(IEnumerable<KeyValuePair<string, Expression>> properties)
        {
            var props = properties.ToList();
            var tupleFactory = Create(props.Select(p => new KeyValuePair<string, Type>(p.Key, p.Value.Type)));
            return tupleFactory.MakeNewExpression(props.Select(p => p.Value));
        }
        private sealed class TupleFactoryImpl : ITupleFactory
        {
            public Type TupleType { get; }
            private readonly ConstructorInfo _ctor;
            private readonly MemberInfo[] _properties;
            public TupleFactoryImpl(Type tupleType, IEnumerable<string> propertyNames)
            {
                TupleType = tupleType;
                _ctor = tupleType.GetConstructors().Single();
                var propsByName = tupleType.GetProperties().ToDictionary(p => p.Name);
                _properties = propertyNames.Select(name => (MemberInfo)propsByName[name]).ToArray();
            }
            public NewExpression MakeNewExpression(IEnumerable<Expression> arguments)
            {
                return Expression.New(_ctor, arguments, _properties);
            }
        }
        /// <summary>
        /// Helper function to pick the optimal op code.
        /// </summary>
        private static void EmitLdarg(ILGenerator il, int index)
        {
            if (index < 0) throw new ArgumentOutOfRangeException();
            switch (index)
            {
                case 0: il.Emit(OpCodes.Ldarg_0); break;
                case 1: il.Emit(OpCodes.Ldarg_1); break;
                case 2: il.Emit(OpCodes.Ldarg_2); break;
                case 3: il.Emit(OpCodes.Ldarg_3); break;
                default:
                    if (index <= byte.MaxValue)
                        il.Emit(OpCodes.Ldarg_S, (byte)index);
                    else if (index <= short.MaxValue)
                        il.Emit(OpCodes.Ldarg, (short)index);
                    else
                        throw new ArgumentOutOfRangeException();
                    break;
            }
        }
        /// <summary>
        /// Helper function to pick the optimal op code.
        /// </summary>
        private static void EmitLdc(ILGenerator il, int i)
        {
            switch (i)
            {
                case -1: il.Emit(OpCodes.Ldc_I4_M1); break;
                case 0: il.Emit(OpCodes.Ldc_I4_0); break;
                case 1: il.Emit(OpCodes.Ldc_I4_1); break;
                case 2: il.Emit(OpCodes.Ldc_I4_2); break;
                case 3: il.Emit(OpCodes.Ldc_I4_3); break;
                case 4: il.Emit(OpCodes.Ldc_I4_4); break;
                case 5: il.Emit(OpCodes.Ldc_I4_5); break;
                case 6: il.Emit(OpCodes.Ldc_I4_6); break;
                case 7: il.Emit(OpCodes.Ldc_I4_7); break;
                case 8: il.Emit(OpCodes.Ldc_I4_8); break;
                default:
                    if (i >= byte.MinValue && i <= byte.MaxValue)
                        il.Emit(OpCodes.Ldc_I4_S, (byte)i);
                    else
                        il.Emit(OpCodes.Ldc_I4, i);
                    break;
            }
        }
    }
    /// <summary>
    /// Compute a hash code.
    /// </summary>
    public struct HashCode
    {
        // magic numbers for hash code
        public const int Seed = 0x20e699b;
        public const int Factor = unchecked((int)0xa5555529);
        private readonly int? _value;
        private HashCode(int value)
        {
            _value = value;
        }
        /// <summary>
        /// Convert to the actual hash code based on what was added so far.
        /// </summary>
        public static implicit operator int(HashCode hc) => hc._value ?? 0;
        /// <summary>
        /// Add a hash code to the state.
        /// </summary>
        /// <returns>An updated <see cref="HashCode"/>.</returns>
        public static HashCode operator +(HashCode hc, int other) => new HashCode(unchecked((hc._value == null ? Seed : hc._value.Value * Factor) + other));
        /// <summary>
        /// Add a sequence of hash code to the state.
        /// </summary>
        /// <returns>An updated <see cref="HashCode"/>.</returns>
        public static HashCode operator +(HashCode hc, IEnumerable<int> others) => others.Aggregate(hc, (a, c) => a + c);
    }
    /// <summary>
    /// <see cref="IEqualityComparer{T}"/> for <see cref="KeyValuePair{TKey, TValue}"/>.
    /// </summary>
    public sealed class KeyValueComparer<TKey, TValue> : IEqualityComparer<KeyValuePair<TKey, TValue>>
    {
        /// <summary>
        /// Gets the singleton.
        /// </summary>
        public static KeyValueComparer<TKey, TValue> Default { get; } = new KeyValueComparer<TKey, TValue>();
        private readonly IEqualityComparer<TKey> _keyComparer;
        private readonly IEqualityComparer<TValue> _valueComparer;
        /// <summary>
        /// Initialize by specifying <see cref="IEqualityComparer{T}"/>s for key and value.
        /// </summary>
        public KeyValueComparer(IEqualityComparer<TKey> keyComparer = null, IEqualityComparer<TValue> valueComparer = null)
        {
            _keyComparer = keyComparer ?? EqualityComparer<TKey>.Default;
            _valueComparer = valueComparer ?? EqualityComparer<TValue>.Default;
        }
        /// <summary>
        /// Equality.
        /// </summary>
        public bool Equals(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y) => _keyComparer.Equals(x.Key, y.Key) && _valueComparer.Equals(x.Value, y.Value);
        /// <summary>
        /// Hash code.
        /// </summary>
        public int GetHashCode(KeyValuePair<TKey, TValue> obj) => new HashCode() + _keyComparer.GetHashCode(obj.Key) + _valueComparer.GetHashCode(obj.Value);
    }
    /// <summary>
    /// <see cref="IEqualityComparer{T}"/> for a collection.
    /// </summary>
    public sealed class CollectionComparer<TElement> : IEqualityComparer<ICollection<TElement>>
    {
        /// <summary>
        /// Gets an instance using <see cref="EqualityComparer{T}.Default"/> as the element comparer.
        /// </summary>
        public static CollectionComparer<TElement> Default { get; } = new CollectionComparer<TElement>();
        private readonly IEqualityComparer<TElement> _elementComparer;
        /// <summary>
        /// Initialize with a specific element comparer.
        /// </summary>
        public CollectionComparer(IEqualityComparer<TElement> elementComparer = null)
        {
            _elementComparer = elementComparer ?? EqualityComparer<TElement>.Default;
        }
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <returns>
        /// true if the specified objects are equal; otherwise, false.
        /// </returns>
        public bool Equals(ICollection<TElement> x, ICollection<TElement> y)
        {
            if (x == null) return y == null;
            if (y == null) return false;
            return x.Count == y.Count && x.SequenceEqual(y, _elementComparer);
        }
        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <returns>
        /// A hash code for the specified object.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> for which a hash code is to be returned.</param>
        public int GetHashCode(ICollection<TElement> obj)
        {
            var result = new HashCode() + typeof(TElement).GetHashCode();
            if (obj == null) return result;
            result += obj.Count;
            result += obj.Select(element => _elementComparer.GetHashCode(element));
            return result;
        }
    }
