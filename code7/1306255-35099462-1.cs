    public string GetNativeRepresentation(int value)
    {
        var nativeDigits = CultureInfo.GetCultureInfo("gu-IN").NumberFormat.NativeDigits;
        return String.Join("", value.ToString().Select(x => nativeDigits[x - '0']));
    }
    
