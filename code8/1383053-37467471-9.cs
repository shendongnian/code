    TextBox1.Text = "php";
    
        ListItem item = DropDownList1.Items.Cast<ListItem>().Where(x => x.Text.ToUpper() == TextBox1.Text.ToUpper()).FirstOrDefault();
        if (item != null)
        {
            DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(item);
            TextBox2.Text = "";
        }
        else
        {
            TextBox2.Text = TextBox1.Text;
            DropDownList1.SelectedIndex = 0;
        }
