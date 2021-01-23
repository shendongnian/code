    byte[] pattern = new byte[] { 0x00, 0xFF, 0x72, 0x96, 0x00, 0xFF, 0x72 };
    ...
    for (int pass = 1; pass <= 7; ++pass)
    {
        ... = pattern[pass];
        ...
    }
