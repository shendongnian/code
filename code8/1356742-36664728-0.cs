    private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboBox cb = sender as ComboBox;
        String Name = cb.Name;
        // Strings are immutable so you need to reassign
        // the result of Replace to the same variable....
        Name = Name.Replace("Rank", "Target");
        // Find returns a Control, you need to cast it as ComboBox
        cb = this.Controls.Find(Name, false) as ComboBox;
        for (int i = cb.SelectedIndex; i < Ranks.Count-1; i++)
        {
        }
    }
