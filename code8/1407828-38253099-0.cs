    public static void ExtractAll(string gcode)
    {
        dataPos = Vector3.zero;
        var match = Regex.Matches(gcode, @"(G|M|X|Y|Z|I|J|K|F)(?<val>-?\d*\.?\d+\.?)");
        for (int i = 0; i < match.Count; i++)
        {
            switch (match[i].Groups[1].Value)
            {
                case "X":
                    dataPos.x = float.Parse(match[i].Groups["val"].Value);
                    break;
                case "Y":
                    dataPos.y = float.Parse(match[i].Groups["val"].Value);
                    break;
                case "Z":
                    dataPos.z = float.Parse(match[i].Groups["val"].Value);
                    break;
            }
        }
        print(dataPos);
    }
