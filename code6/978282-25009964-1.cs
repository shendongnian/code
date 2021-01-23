    private void button6_Click(object sender, EventArgs e)
       {
            try
            {
                da.SelectCommand = new SqlCommand("Select * from Jobs Where Jobs_Date = dateadd(day,datediff(day,1,GETDATE()),0) ", con);
                //  da.SelectCommand = new SqlCommand("Select * from Jobs", con);
                ds.Reset();
                da.Fill(ds);
            }
            catch
            {
                MessageBox.Show("No SQL connection");
            }
            try
            {
                dataGridView1.DataSource = ds.Tables[0];
                bs.DataSource = ds.Tables[0];                
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message, "Error");
            }
            
