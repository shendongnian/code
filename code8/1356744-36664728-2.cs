    private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboBox cb = sender as ComboBox;
        String Name = cb.Name;
        // Strings are immutable so you need to reassign
        // the result of Replace to the same variable....
        Name = Name.Replace("Rank", "Target");
        // Find returns a Control array, you need to add some checking
        // Before using the control instance returned (if found)
        Control[] found = this.Controls.Find(Name, false);
        if(found.Length > 0)
        {
            cb = found[0] as ComboBox;
            if(cb != null)
            {
                for (int i = cb.SelectedIndex; i < Ranks.Count-1; i++)
                {
                    ....
                }
            }
        }
    }
