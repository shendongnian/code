    lbltxt.Visible = false;
    if (ListBox2.SelectedIndex >= 0)
    {
        for (int i = 0; i < ListBox2.Items.Count; i++)
        {
            if (ListBox2.Items[i].Selected)
            {
                if (!arraylist2.Contains(ListBox2.Items[i]))
                {
                    arraylist2.Add(ListBox2.Items[i]);
                }
            }
        }
        for (int i = 0; i < arraylist2.Count; i++)
        {
            if (!ListBox1.Items.Contains(((ListItem)arraylist2[i])))
            {
                ListBox1.Items.Add(((ListItem)arraylist2[i]));
            }
            ListBox2.Items.Remove(((ListItem)arraylist2[i]));
        }
        ListBox1.SelectedIndex = -1;
    }
    else
    {
        lbltxt.Visible = true;
        lbltxt.Text = "Please select atleast one in Listbox2 to move";
    }
