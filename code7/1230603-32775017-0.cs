    lbltxt.Visible = false;
    if (ListBox1.SelectedIndex >= 0)
    {
        for (int i = 0; i < ListBox1.Items.Count; i++)
        {
            if (ListBox1.Items[i].Selected)
            {
                if (!arraylist1.Contains(ListBox1.Items[i]))
                {
                    arraylist1.Add(ListBox1.Items[i]);
                }
            }
        }
        for (int i = 0; i < arraylist1.Count; i++)
        {
            if (!ListBox2.Items.Contains(((ListItem)arraylist1[i])))
            {
                ListBox2.Items.Add(((ListItem)arraylist1[i]));
            }
            ListBox1.Items.Remove(((ListItem)arraylist1[i]));
        }
        ListBox2.SelectedIndex = -1;
    }
    else
    {
        lbltxt.Visible = true;
        lbltxt.Text = "Please select atleast one in Listbox1 to move";
    }
