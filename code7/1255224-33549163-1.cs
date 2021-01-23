    string text = "D1 abc \n E1 \n F1 \n D1 def";
    
    
    string Patter = "^.*D1.*$";
    MatchCollection Mc = Regex.Matches(text, Patter, RegexOptions.Multiline);
    
    
    int index = 0;
    
    Paragraph.Inlines.Clear();
    
    foreach (Match Match in Mc)
    {
        //bold the D1's lines in the RTB
        Paragraph.Inlines.Add(new Run { Text = text.Substring(index, Match.Index - index) });
    
        var bold = new Bold();
    
        bold.Inlines.Add(new Run { Text = text.Substring(Match.Index, Match.Length) });
    
        Paragraph.Inlines.Add(bold);
    
        index = Match.Index + Match.Length;
    }
    
    if (index < text.Length)
    {
        Paragraph.Inlines.Add(new Run { Text = text.Substring(index) });
    }
