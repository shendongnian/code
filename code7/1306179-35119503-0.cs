    						MessageBox.Show(CB1.Text);
            string conn3str = <connection string>;
            OleDbConnection conn3 = new OleDbConnection(conn3str);
            // Get the ID (int) value
            OleDbCommand tblRow2 = new OleDbCommand();
            tblRow2.Connection = conn3;
            tblRow2.CommandText = "select ID from Table1 where NM=  ' " + CB1.Text +" ' ;" ;
            conn3.Open();
            
            // Convert & Pass the command result (tblRow2) to string (info only) & int (for next query) 
            
            string r2 = Convert.ToString(tblRow2.ExecuteScalar());
            Label_1.Text = "ID Code= " + r2;
                        
            int r2i = Convert.ToInt32(tblRow2.ExecuteScalar());
            
            // Select STATUS (string) where TABLE_ID (int) = ID (int)
            OleDbCommand tblRow3 = new OleDbCommand();
            tblRow3.Connection = conn3;
            tblRow3.CommandText = "select STATUS from Table2 where TABLE_ID = " + r2i;
            
            // Convert and Pass command result (tblRow3) to string for next query
            // Where CODE (string) = r3 (string) 
            string r3 = Convert.ToString(tblRow3.ExecuteScalar());
            Label_2.Text = "Current Status = " + r3;
            OleDbCommand tblRow3a = new OleDbCommand();
            tblRow3a.Connection = conn3;
            tblRow3a.CommandText = "select ORDER from Table3 where CODE =  ' " + r3 + " ' ;" ;
            string r3a = Convert.ToString(tblRow3a.ExecuteScalar());
            lblInvCd.Text = "Order = " + r3a;
            MessageBox.Show(r3a);
            // Result is empty even through this same query returns results in the database
