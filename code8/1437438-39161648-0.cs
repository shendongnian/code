     private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Date",typeof(DateTime));
            List<DateTime> str = new List<DateTime>();
            for (int i = 1; i <= 30; i++)
            {
                DataRow row = dt.NewRow();
                if (i < 20)
                    dt.Rows.Add(DateTime.Now.Date.ToShortDateString());
                else
                    dt.Rows.Add(DateTime.Now.Date.AddDays(1).ToShortDateString());
            }
            gcDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            gcDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemComboBox1.DisplayFormat.FormatString = "dd/MM/yyyy";
            repositoryItemComboBox1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemComboBox1.EditFormat.FormatString = "dd/MM/yyyy";
            repositoryItemComboBox1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridControl1.DataSource = dt;
            foreach (DataRow item in dt.Rows)
            {
                repositoryItemComboBox1.Items.Add(Convert.ToDateTime(item["Date"]).ToShortDateString());
            }
        }
    private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "Date" && view.IsFilterRow(e.RowHandle))
            {
                e.RepositoryItem = repositoryItemComboBox1;
            }
        }
