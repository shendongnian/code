    internal class Program
    {
        private static void Main(string[] args)
        {
            var importData = new Dictionary<string, bool>()
            {
                {"Product1", true},
                {"Product2", false},
                {"Product3", true},
            };
            var dt = new DataTable();
            dt.Columns.Add("Product1");
            dt.Columns.Add("Product2");
            dt.Columns.Add("Product3");
            dt.Columns.Add("Product4");
            dt.Columns.Add("Drawing");
            // row1 should be added
            var row1 = dt.NewRow();
            row1["Product1"] = "X";
            row1["Product3"] = "X";
            row1["Drawing"] = "Drawing1";
            dt.Rows.Add(row1);
            // row2 should not be added
            var row2 = dt.NewRow();
            row2["Product1"] = "X";
            row2["Drawing"] = "Drawing2";
            dt.Rows.Add(row2);
            string outDraws = string.Empty;
            foreach (DataRow drow in dt.Rows.OfType<DataRow>())
            {
                if (AllColumnsAreChecked(drow, importData))
                {
                    outDraws += drow["Drawing"].ToString();
                    outDraws += "\n";
                }
            }
            Console.WriteLine(outDraws);
        }
        private static bool AllColumnsAreChecked(DataRow drow, Dictionary<string, bool> importData)
        {
            foreach (var key in importData.Keys)
            {
                if (!importData[key])
                    continue;
                var value = drow[key] as string;
                if (value != "X")
                    return false;
            }
        }
    }
