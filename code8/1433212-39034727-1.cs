        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string fileName = listView1.SelectedItems[0].Text;
            if (fileName.Contains(".xl"))
            {
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                fileName +
                                ";Extended Properties='Excel 12.0;HDR=YES;';";
                OleDbConnection con = new OleDbConnection(constr);
                OleDbCommand oconn = new OleDbCommand("Select * From [Sheet1$]", con);
                con.Open();
                OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
            }
        }
