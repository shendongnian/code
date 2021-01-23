    public static string UcFirst(this string s)
    {
        var stringArr = s.ToCharArray(0, s.Length);
        var char1ToUpper = char.Parse(stringArr[0]
            .ToString()
            .ToUpper());
    
        stringArr[0] = char1ToUpper;
    
        return string.Join("", stringArr);
    }
