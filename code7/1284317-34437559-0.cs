        bool status = false;
      if (RadioButton1.Checked)
        {
            if (ListBox1.Items.Count == 0)
            {
                ListBox1.Items.Add(TextBox1.Text);
                Label2.Text = "<b style='color:green'> item updated in the listbox </b>";
            }
            else 
            {
                foreach (ListItem li in ListBox1.Items)
                {
                    if (li.Text.ToUpper() == TextBox1.Text.ToUpper())
                    {
                        Label2.Text = "<b style='color:red'> access denied </b>";
                        status = true;
                        break;
                    }
                   
                }
                //ListItem item = new ListItem(TextBox1.Text);
                //if (!ListBox1.Items.Contains(item))
                //{
                //    ListBox1.Items.Add(TextBox1.Text);
                //    Label2.Text = "<b style='color:green'> item updated in the listbox </b>";
                //}
                if (status == false)
                {
                    ListBox1.Items.Add(TextBox1.Text);
                    Label2.Text = "<b style='color:green'> item updated in the listbox </b>";
                }
            }
            
        }
