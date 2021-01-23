    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
    byte[] singleByteBuf = new byte[1];
    int max = Byte.MaxValue - Byte.MaxValue % 6;
    while (true) {
        rng.GetBytes(singleByteBuf);
        int b = singleByteBuf[0];
        if (b < max) {
            return b % 6 + 1;
        }
     }
