    private void RunQuery()
            {
                errorMsg = "";
                q = SearchBoxItemsAll.Text;
                try
                {
                    OleDbCommand cmd = new OleDbCommand(q, conn);
                    OleDbDataAdapter a = new OleDbDataAdapter(cmd);
        
                    DataTable dt = new DataTable();
        
                    a.SelectCommand = cmd;
                    a.Fill(dt);
                    a.Dispose();
                    listBox1.DisplayMember = "ITEM NAME";
                    listBox1.ValueMember = "ITEM ID";
                    listBox1.DataSource = dt;
        
        
                }
        }
