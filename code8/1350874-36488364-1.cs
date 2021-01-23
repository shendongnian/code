    StringBuilder sb = new StringBuilder();
    Dictionary<char, char> replacements = new Dictionary<char, char>();
    //put in the pairs
    for (int i = 0; i < unit.Length; i++) {
        if (replacements.ContainsKey(unit[i]))
            sb.Append(replacement[unit[i]];
        else
            sb.Append(unit[i]);
    }
