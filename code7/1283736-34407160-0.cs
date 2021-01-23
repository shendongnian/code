    IEnumerable<string> ShiftIndexes(IEnumerable<string> lines) {
        foreach (string line in lines) {
            if (!string.IsNullOrEmpty(line) && char.IsDigit(line, 0)) {
                int dotPos = line.IndexOf('.');
                int index = int.Parse(line.SubString(0, dotPos));
                yield return (index - 1).ToString() + line.SubString(dotPos);
            }
            else
                yield return line;
        }
    }
