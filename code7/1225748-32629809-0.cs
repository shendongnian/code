    string typed = this.tsComboBoxFontChoice.Text;
    for (int i = 0; i < this.systemFonts.Families.Length; i++)
    {
        string candidate = this.systemFonts.Families[i].Name;
        if (!candidate.StartsWith(typed))
        {
            continue;
        }
 
        // it's a match! 
        ...
    }
