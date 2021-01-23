    for (int i = 0; i < ListBox1.Items.Count; i++)
    {
        ListItem li = ListBox1.Items[i];
        if (li.Text.ToUpper() != TextBox1.Text.ToUpper())
        {
            ListBox1.Items.Add(TextBox1.Text); Label2.Text = "<b style='color:green'> item updated in list box </b>";
        }
        else { Label2.Text = "<b style='color:red'> access denied </b>"; }
    }
