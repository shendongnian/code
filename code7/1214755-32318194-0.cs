    private void send_char_0(string R, string G, string B)
    {
        byte r = byte.Parse(R,NumberStyles.HexNumber);
        byte g = byte.Parse(G,NumberStyles.HexNumber);
        byte b = byte.Parse(B,NumberStyles.HexNumber);
        byte[] data_array = new byte[3]{r,g,b};
     }
