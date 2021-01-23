          private void button1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN");
            DataView myDataView = new DataView();
            DataTable myDataTable = new DataTable();
            myDataTable.Columns.Add("RecordType");
            myDataTable.PrimaryKey = new DataColumn[] { myDataTable.Columns["RecordType"] };
            DataRow dr = myDataTable.NewRow();
            dr["RecordType"] = "NH";
            myDataTable.Rows.Add(dr);
            dr = myDataTable.NewRow();
            dr["RecordType"] = "NTH";
            myDataTable.Rows.Add(dr);
            dr = myDataTable.NewRow();
            dr["RecordType"] = "XH";
            myDataTable.Rows.Add(dr);
            myDataView = myDataTable.DefaultView;
            
            myDataView.RowFilter = "RecordType LIKE 'N*'";
            for (int i = 0; i < myDataView.Count; i++)
                MessageBox.Show(myDataView[i]["RecordType"].ToString());
        }
