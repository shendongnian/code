     var bytes = BitConverter.ToString(BitConverter.GetBytes(123.12));
     // outputs 48-E1-7A-14-AE-C7-5E-40
     var bytes1 = BitConverter.ToString(BitConverter.GetBytes(123.12000000000001));
     // outputs 48-E1-7A-14-AE-C7-5E-40
     var bytes2 = BitConverter.ToString(BitConverter.GetBytes(123.12000000000002));
     // outputs 49-E1-7A-14-AE-C7-5E-40
