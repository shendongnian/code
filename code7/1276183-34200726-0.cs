    BasedValueConverter bvc;
    bvc = new BasedValueConverter(byte.MaxValue.Dump("BasedValueConverter byte"));
    bvc.ToBasedString(BasedValueConverter.Basement.Bin).Dump();  // 11111111
    bvc.ToBasedString(BasedValueConverter.Basement.Oct).Dump();  // 377
    bvc.ToBasedString(BasedValueConverter.Basement.Dec).Dump();  // 255
    bvc.ToBasedString(BasedValueConverter.Basement.Hex).Dump();  // FF
    
    bvc = new BasedValueConverter(byte.MinValue);
    bvc.ToBasedString(BasedValueConverter.Basement.Bin).Dump();  // 00000000
    bvc.ToBasedString(BasedValueConverter.Basement.Oct).Dump();	 // 000
    bvc.ToBasedString(BasedValueConverter.Basement.Dec).Dump();	 // 000
    bvc.ToBasedString(BasedValueConverter.Basement.Hex).Dump();	 // 00
    
    
    
    bvc = new BasedValueConverter(sbyte.MaxValue.Dump("BasedValueConverter sbyte"));
    bvc.ToBasedString(BasedValueConverter.Basement.Bin).Dump();  // 01111111
    bvc.ToBasedString(BasedValueConverter.Basement.Oct).Dump();  // 177
    bvc.ToBasedString(BasedValueConverter.Basement.Dec).Dump();  // 127
    bvc.ToBasedString(BasedValueConverter.Basement.Hex).Dump();  // 7F
    
    bvc = new BasedValueConverter((sbyte)-1);
    bvc.ToBasedString(BasedValueConverter.Basement.Bin).Dump();  // 11111111
    bvc.ToBasedString(BasedValueConverter.Basement.Oct).Dump();  // 377
    bvc.ToBasedString(BasedValueConverter.Basement.Dec).Dump();  // -001
    bvc.ToBasedString(BasedValueConverter.Basement.Hex).Dump();  // FFFFFFFFFFFFFFFF
    
    
    
    bvc = new BasedValueConverter(short.MaxValue.Dump("BasedValueConverter short"));
    bvc.ToBasedString(BasedValueConverter.Basement.Bin).Dump();  // 0111111111111111
    bvc.ToBasedString(BasedValueConverter.Basement.Oct).Dump();  // 077777 
    bvc.ToBasedString(BasedValueConverter.Basement.Dec).Dump();  // 32767
    bvc.ToBasedString(BasedValueConverter.Basement.Hex).Dump();  // 7FFF
    
    bvc = new BasedValueConverter((short)-1);
    bvc.ToBasedString(BasedValueConverter.Basement.Bin).Dump();  // 1111111111111111
    bvc.ToBasedString(BasedValueConverter.Basement.Oct).Dump();  // 177777
    bvc.ToBasedString(BasedValueConverter.Basement.Dec).Dump();  // -00001
    bvc.ToBasedString(BasedValueConverter.Basement.Hex).Dump();  // FFFFFFFFFFFFFFFF
    
    
    
    bvc = new BasedValueConverter(ushort.MaxValue.Dump("BasedValueConverter ushort"));
    bvc.ToBasedString(BasedValueConverter.Basement.Bin).Dump();  // 1111111111111111
    bvc.ToBasedString(BasedValueConverter.Basement.Oct).Dump();  // 177777
    bvc.ToBasedString(BasedValueConverter.Basement.Dec).Dump();  // 65535
    bvc.ToBasedString(BasedValueConverter.Basement.Hex).Dump();  // FFFF
    
    bvc = new BasedValueConverter(ushort.MinValue);
    bvc.ToBasedString(BasedValueConverter.Basement.Bin).Dump();  // 0000000000000000
    bvc.ToBasedString(BasedValueConverter.Basement.Oct).Dump();  // 000000
    bvc.ToBasedString(BasedValueConverter.Basement.Dec).Dump();  // 00000
    bvc.ToBasedString(BasedValueConverter.Basement.Hex).Dump();  // 0000
    
    
    
    bvc = new BasedValueConverter(int.MaxValue.Dump("BasedValueConverter int"));
    bvc.ToBasedString(BasedValueConverter.Basement.Bin).Dump();  // 01111111111111111111111111111111
    bvc.ToBasedString(BasedValueConverter.Basement.Oct).Dump();  // 17777777777
    bvc.ToBasedString(BasedValueConverter.Basement.Dec).Dump();  // 2147483647
    bvc.ToBasedString(BasedValueConverter.Basement.Hex).Dump();  // 7FFFFFFF
    
    bvc = new BasedValueConverter((int)-1);
    bvc.ToBasedString(BasedValueConverter.Basement.Bin).Dump();  // 11111111111111111111111111111111
    bvc.ToBasedString(BasedValueConverter.Basement.Oct).Dump();  // 37777777777
    bvc.ToBasedString(BasedValueConverter.Basement.Dec).Dump();  // -0000000001
    bvc.ToBasedString(BasedValueConverter.Basement.Hex).Dump();  // FFFFFFFFFFFFFFFF
    
    
    
    bvc = new BasedValueConverter(uint.MaxValue.Dump("BasedValueConverter uint"));
    bvc.ToBasedString(BasedValueConverter.Basement.Bin).Dump();  // 11111111111111111111111111111111
    bvc.ToBasedString(BasedValueConverter.Basement.Oct).Dump();  // 37777777777
    bvc.ToBasedString(BasedValueConverter.Basement.Dec).Dump();  // 4294967295
    bvc.ToBasedString(BasedValueConverter.Basement.Hex).Dump();  // FFFFFFFF
    
    bvc = new BasedValueConverter(uint.MinValue);
    bvc.ToBasedString(BasedValueConverter.Basement.Bin).Dump();  // 00000000000000000000000000000000
    bvc.ToBasedString(BasedValueConverter.Basement.Oct).Dump();  // 00000000000
    bvc.ToBasedString(BasedValueConverter.Basement.Dec).Dump();  // 0000000000
    bvc.ToBasedString(BasedValueConverter.Basement.Hex).Dump();  // 00000000
    
    
    
    bvc = new BasedValueConverter(long.MaxValue.Dump("BasedValueConverter long"));
    bvc.ToBasedString(BasedValueConverter.Basement.Bin).Dump();  // 0111111111111111111111111111111111111111111111111111111111111111
    bvc.ToBasedString(BasedValueConverter.Basement.Oct).Dump();  // 0777777777777777777777
    bvc.ToBasedString(BasedValueConverter.Basement.Dec).Dump();  // 9223372036854775807
    bvc.ToBasedString(BasedValueConverter.Basement.Hex).Dump();  // 7FFFFFFFFFFFFFFF
    
    bvc = new BasedValueConverter((long)-1);
    bvc.ToBasedString(BasedValueConverter.Basement.Bin).Dump();  // 1111111111111111111111111111111111111111111111111111111111111111
    bvc.ToBasedString(BasedValueConverter.Basement.Oct).Dump();  // 1777777777777777777777
    bvc.ToBasedString(BasedValueConverter.Basement.Dec).Dump();  // -00000000000000000001
    bvc.ToBasedString(BasedValueConverter.Basement.Hex).Dump();  // FFFFFFFFFFFFFFFF
    
    
    
    bvc = new BasedValueConverter(ulong.MaxValue.Dump("BasedValueConverter ulong"));
    bvc.ToBasedString(BasedValueConverter.Basement.Bin).Dump();  // 1111111111111111111111111111111111111111111111111111111111111111
    bvc.ToBasedString(BasedValueConverter.Basement.Oct).Dump();  // 1777777777777777777777
    bvc.ToBasedString(BasedValueConverter.Basement.Dec).Dump();  // -00000000000000000001
    bvc.ToBasedString(BasedValueConverter.Basement.Hex).Dump();  // FFFFFFFFFFFFFFFF
    
    bvc = new BasedValueConverter(ulong.MinValue);
    bvc.ToBasedString(BasedValueConverter.Basement.Bin).Dump();  // 0000000000000000000000000000000000000000000000000000000000000000
    bvc.ToBasedString(BasedValueConverter.Basement.Oct).Dump();  // 0000000000000000000000
    bvc.ToBasedString(BasedValueConverter.Basement.Dec).Dump();  // 00000000000000000000
    bvc.ToBasedString(BasedValueConverter.Basement.Hex).Dump();  // 0000000000000000
