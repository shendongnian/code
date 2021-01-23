    var multiLineString = "Most at-home desensitizing toothpastes work by" + Environment.NewLine +
        "primarily numbing the nerve and masking the pain" + Environment.NewLine +
        "Traditional potassium iron-based toothpastes in the" + Environment.NewLine +
        "form of potassium nitrate, potassium citrate.";
    var lines = multiLineString
        .Split(Environment.NewLine);
    for(Int32 i = 0; i < 3; i++)
    {
         lines[i] = lines[i].Replace("potassium ", "");
    }
    var resultingLine = String.Join(lines, Environment.NewLine))
