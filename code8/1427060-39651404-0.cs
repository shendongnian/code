        private void MySQL_ToDatagridview4()
    {
        dataGridView3.Columns.Clear();
        mcon.Close();
        mcon.Open();
        MySqlDataAdapter MyDA = new MySqlDataAdapter();
        string sqlSelectAll = "SELECT Item_Name,Item_Pic from stockitem ORDER BY Main_Category_ID ASC, Item_Name ASC";
        MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, mcon);
        DataTable table = new DataTable();
        MyDA.Fill(table);
        BindingSource bSource = new BindingSource();
        bSource.DataSource = table;
        this.dataGridView3.DataSource = bSource;
        DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
        imageColumn.HeaderText = "Pic";
        dataGridView3.Columns.Insert(0, imageColumn);
        for (int i = 0; i < table.Rows.Count; i++)
        {
            try
            {
                String pic = table.Rows[i]["Item_Pic"].ToString();
                Byte[] bitmapData = Convert.FromBase64String(FixBase64ForImage(pic));
                System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);
                def = new Bitmap((Bitmap)Image.FromStream(streamBitmap));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            dataGridView3.Rows[i].Cells[0].Value = def;
        }
        dataGridView3.Columns.Remove("Item_Pic");
        foreach (DataGridViewRow row in dataGridView3.Rows)
        {
            row.Height = 110;
        }
        foreach (DataGridViewColumn col in dataGridView3.Columns)
        {
            col.Width = 110;
        }
    
        for (int i = 0; i < dataGridView3.ColumnCount; i++)
        {
            dataGridView3.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView3.AutoResizeColumns();
            dataGridView3.Columns[i].DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 8F, FontStyle.Bold);
        }
        mcon.Close();
    }
