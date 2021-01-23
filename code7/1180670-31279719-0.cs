    byte[] ilCodes = new byte[5];
    int token = module.GetMetadataToken(methodFromOtherAssembly).Token;
    ilCodes[0] = (byte)OpCodes.Jmp.Value;
    ilCodes[1] = (byte)(token & 0xFF);
    ilCodes[2] = (byte)(token >> 8 & 0xFF);
    ilCodes[3] = (byte)(token >> 16 & 0xFF);
    ilCodes[4] = (byte)(token >> 24 & 0xFF);
