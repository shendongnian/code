    public static Kolor Read()
    {
        byte _red = GetByte("R");
        byte _green = GetByte("G");
        byte _blue = GetByte("B");
        return new Kolor(_red, _green, _blue);
    }
    private static byte GetByte(string key)
    {
         if (!ApplicationData.Current.LocalSettings.Values.ContainsKey(key))
         {
             return default(byte);
         }
         return (byte)(ApplicationData.Current.LocalSettings.Values[key]);
    }
