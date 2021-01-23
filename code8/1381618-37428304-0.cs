            string oradb = "User id =test;password=test1;Datasource=oracle";
            OracleConnection conn = new OracleConnection(oradb);  
            conn.Open();
            using (OracleDataAdapter  a = new OracleDataAdapter(
		            "SELECT id FROM emp1", conn))
		        {
		            DataTable t = new DataTable();
		            a.Fill(t);
		            // Render data onto the screen
		            dataGridView1.DataSource = t;
		        }
	          
            conn.Dispose();
