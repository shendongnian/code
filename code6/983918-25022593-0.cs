        private static void Main(string[] args)
        {
            var itemsOnSkid = CreateDataTable();
            FillData(itemsOnSkid);
            var result = itemsOnSkid.AsEnumerable().GroupBy(row => row.Field<string>("ItemNumber")).Select(
                grp =>
                    {
                        var newRow = resultDataTable.NewRow();
                        newRow["ItemNumber"] = grp.Key;
                        newRow["Qty"] = grp.Sum(r => r.Field<int>("Qty"));
                        return newRow;
                    }).CopyToDataTable();
        }
        private static DataTable CreateDataTable()
        {
            var itemsOnSkid = new DataTable();
            itemsOnSkid.Columns.Add("ItemNumber");
            itemsOnSkid.Columns.Add("Qty", typeof(int));
            return itemsOnSkid;
        }
        // Fill some Data in the Table
        private static void FillData(DataTable itemsOnSkid)
        {
            for (int i = 1; i <= 10; i++)
            {
                var newRow = itemsOnSkid.NewRow();
                newRow["ItemNumber"] = i % 3;
                newRow["Qty"] = i;
                itemsOnSkid.Rows.Add(newRow);
            }
        }
