     protected void ddlname_SelectedIndexChanged(object sender, EventArgs e)
     {
            string record = ddlname.SelectedItem.Value.ToString();
            DataTable dt = adm.GetRecords(record ) 
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                string value = dt.Rows[i][1].ToString();
                for (int j = 0; j < ddl.Items.Count; j++)
                {
                    
                    string value1 = ddl.Items[j].ToString();
                    if (value == value1)
                    {
                        ddl.Items.RemoveAt(j);
                        
                        break;
                    }
                }
            }
     }
