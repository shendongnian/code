     protected void ddlbatchname_SelectedIndexChanged(object sender, EventArgs e)
     {
            string batchname = ddlbatchname.SelectedItem.Value.ToString();
            DataTable dt = adm.GetRecords(batchname);
            BindDay(); 
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                string value = dt.Rows[i][1].ToString();
                for (int j = 0; j < ddlday.Items.Count; j++)
                {
                    
                    string value1 = ddlday.Items[j].ToString();
                    if (value == value1)
                    {
                        ddlday.Items.RemoveAt(j);
                        //BindDay();
                        break;
                    }
                }
            }
     }
