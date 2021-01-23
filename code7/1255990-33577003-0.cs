    public static decimal RecreateDecimal(decimal input)
    {
        var bits = decimal.GetBits(input);
        var d = new DynamicMethod("recreate", typeof(decimal), null);
        var il = d.GetILGenerator();
        
        il.Emit(OpCodes.Ldc_I4_4);
        il.Emit(OpCodes.Newarr, typeof(int));
        il.Emit(OpCodes.Dup);
        il.Emit(OpCodes.Ldc_I4_0);
        il.Emit(OpCodes.Ldc_I4, bits[0]);
        il.Emit(OpCodes.Stelem_I4);
        il.Emit(OpCodes.Dup);
        il.Emit(OpCodes.Ldc_I4_1);
        il.Emit(OpCodes.Ldc_I4, bits[1]);
        il.Emit(OpCodes.Stelem_I4);
        il.Emit(OpCodes.Dup);
        il.Emit(OpCodes.Ldc_I4_2);
        il.Emit(OpCodes.Ldc_I4, bits[2]);
        il.Emit(OpCodes.Stelem_I4);
        il.Emit(OpCodes.Dup);
        il.Emit(OpCodes.Ldc_I4_3);
        il.Emit(OpCodes.Ldc_I4, bits[3]);
        il.Emit(OpCodes.Stelem_I4);
        il.Emit(OpCodes.Newobj, typeof(decimal).GetConstructor(new[] {typeof(int[])}));
        il.Emit(OpCodes.Ret);
        return (decimal) d.Invoke(null, null);
    }
