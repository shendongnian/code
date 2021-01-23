    Output0Buffer.AgeName = LmySpread.Elements[0].Value;
    if (LmySpread.Elements.Length >= 2)
    {
        Output0Buffer.LowerBound = Int32.Parse(LmySpread.Elements[1].Value);
    }
    if (LmySpread.Elements.Length >= 3)
    {
        Output0Buffer.UpperBound = Int32.Parse(LmySpread.Elements[2].Value);
    }
