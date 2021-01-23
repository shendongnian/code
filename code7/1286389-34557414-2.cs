    public static class DecimalUtils
    {
        public static decimal ParseExact(string s, NumberStyles style = NumberStyles.Number, IFormatProvider provider = null)
        {
            // NOTE: Always call base method first 
            var value = decimal.Parse(s, style, provider);
            if (!IsValidPrecision(s, style, provider))
                throw new InvalidCastException(); // TODO: throw appropriate exception
            return value;
        }
    
        public static bool TryParseExact(string s, out decimal result, NumberStyles style = NumberStyles.Number, IFormatProvider provider = null)
        {
            // NOTE: Always call base method first 
            return decimal.TryParse(s, style, provider, out result) && !IsValidPrecision(s, style, provider);
        }
    
        static bool IsValidPrecision(string s, NumberStyles style, IFormatProvider provider)
        {
            var precision = GetPrecision(s, style, NumberFormatInfo.GetInstance(provider));
            return precision <= 29;
        }
    
        static readonly Func<string, NumberStyles, NumberFormatInfo, int> GetPrecision = BuildGetPrecisionFunc();
        static Func<string, NumberStyles, NumberFormatInfo, int> BuildGetPrecisionFunc()
        {
            const BindingFlags Flags = BindingFlags.Public | BindingFlags.NonPublic;
            const BindingFlags InstanceFlags = Flags | BindingFlags.Instance;
            const BindingFlags StaticFlags = Flags | BindingFlags.Static;
    
            var numberType = typeof(decimal).Assembly.GetType("System.Number");
            var numberBufferType = numberType.GetNestedType("NumberBuffer", Flags);
    
            var method = new DynamicMethod("GetPrecision", typeof(int),
                new[] { typeof(string), typeof(NumberStyles), typeof(NumberFormatInfo) },
                typeof(DecimalUtils), true);
    
            var body = method.GetILGenerator();
            // byte* buffer = stackalloc byte[Number.NumberBuffer.NumberBufferBytes];
            var buffer = body.DeclareLocal(typeof(byte*));
            body.Emit(OpCodes.Ldsfld, numberBufferType.GetField("NumberBufferBytes", StaticFlags));
            body.Emit(OpCodes.Localloc);
            body.Emit(OpCodes.Stloc, buffer.LocalIndex);
            // var number = new Number.NumberBuffer(buffer);
            var number = body.DeclareLocal(numberBufferType);
            body.Emit(OpCodes.Ldloca_S, number.LocalIndex);
            body.Emit(OpCodes.Ldloc, buffer.LocalIndex);
            body.Emit(OpCodes.Call, numberBufferType.GetConstructor(InstanceFlags, null,
                new[] { typeof(byte*) }, null));
            // Number.TryStringToNumber(value, options, ref number, numfmt, true);
            body.Emit(OpCodes.Ldarg_0);
            body.Emit(OpCodes.Ldarg_1);
            body.Emit(OpCodes.Ldloca_S, number.LocalIndex);
            body.Emit(OpCodes.Ldarg_2);
            body.Emit(OpCodes.Ldc_I4_1);
            body.Emit(OpCodes.Call, numberType.GetMethod("TryStringToNumber", StaticFlags, null,
                new[] { typeof(string), typeof(NumberStyles), numberBufferType.MakeByRefType(), typeof(NumberFormatInfo), typeof(bool) }, null));
            body.Emit(OpCodes.Pop);
            // return number.precision;
            body.Emit(OpCodes.Ldloca_S, number.LocalIndex);
            body.Emit(OpCodes.Ldfld, numberBufferType.GetField("precision", InstanceFlags));
            body.Emit(OpCodes.Ret);
    
            return (Func<string, NumberStyles, NumberFormatInfo, int>)method.CreateDelegate(typeof(Func<string, NumberStyles, NumberFormatInfo, int>));
        }
    }
