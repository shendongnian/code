    String names = "";
    for (int i = 0; i < mydataGrid.Items.Count; i++)
    {
        var newrow = (My_DTO)mydataGrid.Items[i];
        names += newrow.FirstName.ToString());
    }
    MessageBox.Show(names);
