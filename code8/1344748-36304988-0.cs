        private void GoButton_Click(object sender, EventArgs e) {
            string constr = "Provider = MicroSoft.Jet.OLEDB.4.0; Data Source=" + locTBox.Text + ";Extended Properties =\"Excel 8.0; HDR=NO;\";";
            OleDbConnection con = new OleDbConnection(constr);
            OleDbDataAdapter sda = new OleDbDataAdapter("Select * From [" + shTBox.Text + "$]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CleanupDataTable(dt); // call the cleanup here, before binding dgv to dt
            dGVPlan.DataSource = dt;
            new SearchWindow(this).Show();
            //this.Show(); why you are calling show() here?
        }
        private void CleanupDataTable(DataTable dt) {
            if(dt.Rows.Count == 0)
                return;
            var headerRow = dt.Rows[0];
            var columns = headerRow.ItemArray;
            // 1. give the right column names
            for(int i = 0, l = columns.Length; i < l; i++)
                dt.Columns[i].ColumnName = columns[i].ToString();
            // 2. remove the header row from the result
            dt.Rows.Remove(headerRow);
        }
