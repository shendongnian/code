    public static Color From0BGR(int bgrColor)
    {
        // Get the color bytes
        var bytes = BitConverter.GetBytes(bgrColor);
    
        // Return the color from the byte array
        return Color.FromArgb(bytes[0], bytes[1], bytes[2]);
    }
