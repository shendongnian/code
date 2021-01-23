    List<string> charSets = new List<string>();
    if (cbLowercase.Checked)
        charSets.Add(NonCapitilizedLetters);
    if (cbUppercase.Checked)
        charSets.Add(CapitilizedLetters);
    if (cbNumbers.Checked)
        charSets.Add(Numbers);
    if (cbSpecial.Checked)
        charSets.Add(SpecialCharacters);
    if (charSets.Count < 1)
        // Tell them they need to check at least 1 box or whatever
    int length = int.Parse(txtLength.Text);
    StringBuilder sb = new StringBuilder();
    while (lenth-- > 0)
    {
        int charSet = random.Next(charSets.Count);
        int index = random.Next(charSets[charSet].Length);
        sb.Append(charSets[charSet][index]);
    }
    string password = sb.ToString();
