    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ListBox1.Items.Count > 0)
        {
            foreach (ListItem item in ListBox1.Items)
            {
               if (item.Selected == true)
               {
                   //insert your code that adds the selected item to the panel you have
               }
            }
        }
    }
