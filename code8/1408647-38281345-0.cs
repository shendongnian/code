    int val;
    if(int.TryParse(str, System.Globalization.NumberStyles.HexNumber, out val))
    {
        // The parsing succeeded, so you can continue with the integer you have 
        // now in val. 
    }
