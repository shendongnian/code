        public IEnumerable<DataRow> SelectDataRow()
        {
            ....
            using (var reader = cmd.ExecuteReader())
            {
                var table = new DataTable();
                table.BeginLoadData();
                table.Load(reader);
                table.EndLoadData();
                return table.AsEnumerable(); // in assembly: System.Data.DataSetExtensions
            }
        }
