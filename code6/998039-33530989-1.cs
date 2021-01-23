    List<object> list = new List<object>();
            System.Data.DataTable DT2 = new System.Data.DataTable();
            private void button1_Click(object sender, EventArgs e)
            {
                foreach (DataRow row in DT2.Rows)
                {
                    for (int i = 0; i < DT2.Rows.Count; i++)
                    {
                        var Tjek = DT2.Rows[i][0];
                        if (list.Contains(DT2.Rows[i][0]))
                        {
    
                        }
                    else
                    {
                        
                        
                        list.Add(Tjek);
                    }
                   
                }
            }
        }
