    for (int i = 0; i < listBoxOriginal.Items.Count; i++)
    {
        string linkurl = listBoxOriginal.Items[i].ToString() + "..";
        listBoxNewListBox.SelectedIndex = 0;
        for (int o = 0; o < listBoxNewListBox.Items.Count; o++)
        {
            string s = listBoxNewListBox.Items[o] as string;
            string newurl = s.Replace("DOMAIN", linkurl);
            listBoxNewListBox.SelectedIndex = o;
        }
    }
