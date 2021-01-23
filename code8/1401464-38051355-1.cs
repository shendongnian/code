     protected void button1_Click(object sender, EventArgs e)  
        {  
            foreach (GridViewRow gvrow in dataGridView1.Rows)  
            {  
                CheckBox chk = (CheckBox)gvrow.FindControl("chkSelect");  
                if (chk != null & chk.Checked)  
                {  
                    SqlConnection conn1 = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=acc;Integrated Security=True");
                    SqlCommand cmd1 = new SqlCommand(@"select db.date,db.type,db.refno,db.itmcod,db.qty,db.cuscod, db.cstcod,cus.cusnam INTO ##wec from fstktxn as db INNER JOIN fcustomer as cus on db.cuscod = cus.cuscod where itmcod = "dataGridView1.Cells["title"].Value", ", conn1);
                    conn1.Open();
                    cmd1.ExecuteNonQuery();
                   SqlBulkCopy bulkCopy = new SqlBulkCopy(conn1);
                   bulkCopy.DestinationTableName = "##tmp1";
                   conn1.Close();//Do something 
                }  
            }         
        }  
