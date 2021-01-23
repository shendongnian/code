          string strSql = "Select * from cust";
          OleDbConnection con = new OleDbConnection(strProvider);
          OleDbCommand cmd = new OleDbCommand(strSql, con);
          con.Open();
          cmd.CommandType = CommandType.Text;
          OleDbDataAdapter da = new OleDbDataAdapter(cmd);
          DataTable scores = new DataTable();
          da.Fill(scores);
          dglist.DataSource = scores;
          DataView dv = new DataView(scores);
          dv.RowFilter = string.Format("name LIKE '%{0}%'", txtsearch.Text);
          dglist.DataSource = dv;
       
