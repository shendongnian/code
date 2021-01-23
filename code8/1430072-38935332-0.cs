                // Let Say We have Student's Current state is USA
            string curruntState = "USA";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (curruntState.ToUpper() == reader["State"].ToString().ToUpper())
                {
                    ListItem item = new ListItem(reader["State"].ToString(), reader["StateID"].ToString());
                    item.Selected = true;
                    ddStates.Items.Add(item);
                }
                else
                {
                    ListItem item = new ListItem(reader["State"].ToString(), reader["StateID"].ToString());
                    item.Selected = false;
                    ddStates.Items.Add(item);
                }
            }
            ddStates.DataBind();
            reader.Close();
 
