     // adding sql commands to your checkedlistbox:
    checkedListBox1.Items.Add("SELECT * FROM Table_1");
    
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Server=localhost;Database=myDatabase;User Id=sa;Password = Password; ";
        
        
                string str = "";
        
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        str = (string)checkedListBox1.Items[i];
                        textBox1.Text = str;
        
                        SqlCommand cmd = new SqlCommand(str, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
