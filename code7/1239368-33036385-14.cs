    public static string lol()
    {
        string source = "Alu-Dreieckstütze";
        // System.Text.Encoding encSource = System.Text.Encoding.Default;
        System.Text.Encoding encSource = System.Text.Encoding.GetEncoding(28591);
        System.Text.Encoding encTarget = System.Text.Encoding.ASCII;
        byte[] encoded = encSource.GetBytes(source);
        string broken = encTarget.GetString(encoded);
        return broken;
    }
