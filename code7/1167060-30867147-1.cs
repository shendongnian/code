    // cases <- expand.grid(x=1:3, y=letters[1:3])
    var letterCases = engine.Evaluate("cases[,'y']").AsCharacter().ToArray();
    // Equivalent:
    var df = engine.GetSymbol("cases").AsDataFrame();
    letterCases = df[1].AsCharacter().ToArray();
    letterCases = df["y"].AsCharacter().ToArray();
