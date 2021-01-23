      foreach (DataRowView dvrow in catcombobox.Items)
                {
                if (dvrow.ToString() == addcattxt.Text)
                    {
                        MessageBox.Show("This category already exists.", "Invalid Operation: Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                else{
                        using (var sqlcmd = new SqlCommand("INSERT INTO category_table (Category) VALUES(@cat);", sqlconnection))
                    {
                        sqlcmd.Parameters.AddWithValue("@cat", this.addcattxt.Text);
                        sqlcmd.ExecuteNonQuery();
                    }
                 }
