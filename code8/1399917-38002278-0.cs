    if (ListViewCostumControl.lvnf.Items[i].Text.ToLower().Contains(textBox4.Text.ToLower()))
    {
        ListViewCostumControl.lvnf.Items[i].ForeColor = color;
    }
    else 
    {
        ListViewCostumControl.lvnf.Items[i].ForeColor = Color.Black;
    }
