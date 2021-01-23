    private void btnFirst_Click(object sender, EventArgs e)
            {
           conString =Properties.Settings.Default.TransportationConnectionString;
           con.ConnectionString = conString;
           System.Data.OleDb.OleDbCommand cmd1 = new System.Data.OleDb.OleDbCommand();
           cmd1.Connection = con;
                for(inc=0;inc<listView1.Items.Count;inc++)
                {
    
                    cmd1.CommandText="";
    		con.Open();
    		cmd1.CommandText = "INSERT INTO [BillingGrd] ([InvoiceNo],[FromLocation],[ToLocation],[Material],[Trip],[MetricTon],[BillWeight],[Rate],[BillAmount],[GrandTotal]) Values ('"+txtBilNo.Text+"','"+listView1.Items[inc].SubItems[0].Text+"','"+listView1.Items[inc].SubItems[1].Text+"','"+listView1.Items[inc].SubItems[2].Text+"','"+listView1.Items[inc].SubItems[3].Text+"','"+listView1.Items[inc].SubItems[4].Text+"','"+listView1.Items[inc].SubItems[5].Text+"','"+listView1.Items[inc].SubItems[6].Text+"','"+listView1.Items[inc].SubItems[7].Text+'")";
                    cmd1.ExecuteNonQuery();//error here datatype mismatch
                    con.Close();  
           
                  }                 
                               
              }
