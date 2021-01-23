     private void button1_Click(object sender, EventArgs e)
            {
                DataTable table = new DataTable();
    
                DataColumn col1 = new DataColumn("Name");
                DataColumn col2 = new DataColumn("Username");
                DataColumn col3 = new DataColumn("tr");
                col3.DataType = System.Type.GetType("System.Boolean");
    
    
                col1.DataType = System.Type.GetType("System.String");
                col2.DataType = System.Type.GetType("System.String");
    
                table.Columns.Add(col1);
                table.Columns.Add(col2);
                table.Columns.Add(col3);
    
    
                DataRow row = table.NewRow();
                row[col1] = "John";
                row[col2] = "John123";
                row[col3] = true ;
    
                table.Rows.Add(row);
    
    
                 row = table.NewRow();
                row[col1] = "John1111";
                row[col2] = "John1225";
                row[col3] = false ;
    
                table.Rows.Add(row);
    
                row = table.NewRow();
                row[col1] = "John222";
                row[col2] = "John3333";
                row[col3] = true ;
    
                table.Rows.Add(row);
    
    
                row = table.NewRow();
                row[col1] = "John3333";
                row[col2] = "Jogggazg";
                row[col3] = false ;
    
                table.Rows.Add(row);
    
    
                dataGridView1.DataSource = table;
            }
     private void button2_Click(object sender, EventArgs e)
            {
                DataGridViewRow roow = new DataGridViewRow(); ;
                int rcnt = dataGridView1.Rows.Count - 2;
                int ccnt = dataGridView1.Rows[0].Cells.Count - 1;
                for (int i = 0; i <= rcnt; i++)
                {
                    roow = dataGridView1.Rows[i];
                    DataGridViewCheckBoxCell ischecked = roow.Cells[ccnt] as DataGridViewCheckBoxCell;
                    if ( (bool)ischecked.Value == true)
                    {
                        for (int j = 0; j <= ccnt; j++)
                        {
                            dataGridView1.Rows[rcnt].Cells[j].ReadOnly = true;
                        }
                    }
                
                }          
            }
