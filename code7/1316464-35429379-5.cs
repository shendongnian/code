    public static string DecodeFromArmSCII8(string str) {
        // copy the string as UTF-8 bytes.
        byte[] bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(str);
        return new ArmSCII8EncodingFast().GetString(bytes);
    }
