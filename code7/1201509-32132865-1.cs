     if (dropdown.SelectedIndex != -1)
        {
            ListItem mySelectedItem = (from ListItem li in dropdown.Items where li.Selected == true select li).First();
            foreach (GridViewRow rw in GridView2.Rows)
            {
                Label tv = (Label)rw.Cells[3].FindControl("City");
                if (tv.Text.IndexOf(mySelectedItem.Text) != -1)
                {
                    rw.Visible = true;
                }
                else
                    rw.Visible = false;
            }
        }
