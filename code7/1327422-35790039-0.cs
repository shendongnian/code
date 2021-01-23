    public IEnumerable<string> GetCodes(string data)
    {
        var lines = data.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        foreach (var line in lines)
        {
            for (var i = 0; i < line.Length; i++)
            {
                if (!char.IsLetter(line[i]))
                    continue;
                var text = line.Substring(i).TrimEnd(' ');
                yield return text;
                break;
            }
        }
    }
