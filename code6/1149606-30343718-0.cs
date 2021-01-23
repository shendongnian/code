        decimal decValue = 989.99M;
        string hexValue = decValue.ToString("X");
        //Convert to float(24)/Single-precision floating-point format/ IEEE 754-2008/ binary32.
       
        byte[] raw = new byte[hexValue.Length / 2];
        for (int i = 0; i < raw.Length; i++)
        {
            raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            raw[raw.Length - i - 1] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        }
        float f = BitConverter.ToSingle(raw, 0);
