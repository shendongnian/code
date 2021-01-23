    public class DataRowModel
        {
            public object FirstCellData { get; set; }
            public object SecondCellData { get; set; }
            //... for every column in DataRow
            public object LastCellData { get; set; }
            public DataRowModel (DataRow row)
            {
                this.FirstCellData = row["FIELD_1"] ;
                this.SecondCellData = row["FIELD_2"];
                this.LastCellData = row["FIELD_3"];
            }
        }
