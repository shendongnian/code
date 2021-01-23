    var multiLineString = "Most at-home desensitizing toothpastes work by" + Environment.NewLine +
        "primarily numbing the nerve and masking the pain" + Environment.NewLine +
        "Traditional potassium iron-based toothpastes in the" + Environment.NewLine +
        "form of potassium nitrate, potassium citrate.";
    var lines = multiLineString
        .Split(Environment.NewLine);
    lines[lines.Length-1] = lines[lines.Length-1].Replace("potassium ", "");
    var resultingLine = String.Join(lines, Environment.NewLine))
