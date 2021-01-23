    static char Color2Char(Color c)
    {
        Byte[] result = {0xff,0xff};
        var red = (c.R >> 3) ;
        var green = (c.G >> 3) ;
        var blue = (c.B >> 2);
        result[0] = (byte)(red << 3);
        result[0] = (byte)(result[0] + (green >> 2));
        result[1] = (byte)(green << 6);
        result[1] = (byte)(result[1] + blue);
        return (char)System.Text.Encoding.UTF8.GetChars(result)[0];
    }
