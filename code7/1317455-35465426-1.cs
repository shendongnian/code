    Parameter FromHexString(string text)
    {
        Parameter parameter = new Parameter();
        parameter.Typ = Parameter.ParamaterTyp.k1001;
        parameter.LowerBorder = int.Parse(
            text.Substring(0, text.Length - 1), NumberStyles.AllowHexSpecifier);
    }
    Parameter FromInt32(string text)
    {
        Parameter parameter = new Parameter();
        parameter.Typ = Parameter.ParamaterTyp.k1000;
        parameter.LowerBorder = int.Parse(text);
    }
