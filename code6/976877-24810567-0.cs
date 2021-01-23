    using (var command = new SqlCommand(query, conn))
    {
    
        foreach (var item in CheckBoxList1.Items.Cast<ListItem>().Where(item => item.Selected))
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@planName", item.Text);
            // If you don't reset the Optional here the next loop on CheckBoxList1 add
            // to the current value of Optional giving an invelid string
            string Optional = "";
            foreach (var item1 in CheckBoxList2.Items.Cast<ListItem>().Where(item1 => item1.Selected))
            {
                    Optional = Optional + item1.Text;
            }
            command.Parameters.AddWithValue("@optionPlan", Optional);
            command.ExecuteNonQuery();
        }
    }
