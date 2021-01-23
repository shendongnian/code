    var bits = decimal.GetBits(d);
    bool sign = (bits[3] & 0x80000000) != 0;
    int scale = (byte)((bits[3] >> 16) & 0x7f);
    gen.Emit(OpCodes.Ldc_I4, bits[0]);
    gen.Emit(OpCodes.Ldc_I4, bits[1]);
    gen.Emit(OpCodes.Ldc_I4, bits[2]);
    gen.Emit(sign ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0);
    gen.Emit(OpCodes.Ldc_I4, scale);
    var ctor = typeof(decimal).GetConstructor(new[] { typeof(int), typeof(int), 
                                                    typeof(int), typeof(bool), typeof(byte) });
    gen.Emit(OpCodes.Newobj, ctor);
    gen.Emit(OpCodes.Ret);
