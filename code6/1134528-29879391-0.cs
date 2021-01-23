        static void Main(string[] args)
        {
            List<string> ExampleData = new List<string> { "my", "intestesting", "data" };
            using (ExcelPackage package = new ExcelPackage(new FileInfo(@"C:\Temp\example.xlsm")))
            {
                ExcelWorksheet ws = package.Workbook.Worksheets["MySheet"];
                int lastRowIndex = ws.Dimension.End.Row;
                int idx = lastRowIndex + 1;
                foreach (var datum in ExampleData)
                {
                    ws.Cells[idx, 1].Value = datum;
                    idx++;
                }
                package.Save();
            }
        }
