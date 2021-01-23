        public IEnumerable<DataRow> SelectDataRow()
        {
            ....
            var table = new DataTable();
            table.BeginLoadData();
            table.Load(cmd.ExecuteReader());
            table.EndLoadData();
            return table.AsEnumerable();
        }
