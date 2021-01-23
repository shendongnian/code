        DataTable dataTable;
        private void Form1_Load(object sender, EventArgs e)
        {
            prepareDataGridView();
        }
        public void prepareDataGridView()
        {
            dataTable = new DataTable();
            addColumnsToDataTable(dataTable);
            fillDataTable();
            avaEditDataGridViewImport.DataSource = dataTable;
            //addHeaderCheckBox();
            addButtonsToUnactiveRows();
            //styleDataGrid();
        }
        public void addColumnsToDataTable(DataTable dataTable)
        {
            dataTable.Columns.Add("check");
            dataTable.Columns.Add("Position");
            dataTable.Columns.Add("Positionsindex");
            dataTable.Columns.Add("Textindex");
            dataTable.Columns.Add("Stichwort");
            dataTable.Columns.Add("Menge");
            dataTable.Columns.Add("EH");
            dataTable.Columns.Add("Active");
        }
        private void fillDataTable()
        {
            for (int j = 1; j <= 10; j++)
            {
                dataTable.Rows.Add(j.ToString(), j, j, j, j, j, j, (j % 2 == 0 ? true : false));
            }
        }
        public void addButtonsToUnactiveRows()
        {
            foreach (DataGridViewRow row in avaEditDataGridViewImport.Rows)
            {
                if (row.Cells["Active"].Value.ToString().Equals("False"))
                {
                    DataGridViewButtonCell buttonCell = new DataGridViewButtonCell();
                    row.Cells["check"] = buttonCell;
                }
            }
        }
