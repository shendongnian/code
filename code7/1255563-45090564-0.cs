        ...
        DataSet ds;
        ...
        foreach(DataTable dtbl in ds.Tables)
        {
            foreach(DataColumn dcol in dtbl.Columns)
            {
                if (dcol.ColumnMapping == MappingType.Hidden)
                {
                    dcol.ColumnMapping = MappingType.Element;
                }
            }
        }
        DataGridView.DataSource = ds;
