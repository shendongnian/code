        public void Formula_Calc_Test()
        {
            var datatable = new DataTable("tblData");
            datatable.Columns.AddRange(new[] {new DataColumn("Col1", typeof (int)), new DataColumn("Col2", typeof (int))});
            for (var i = 0; i < 10; i++)
            {
                var row = datatable.NewRow();
                row[0] = i;
                row[1] = i * 10;
                datatable.Rows.Add(row);
            }
            using (var pck = new ExcelPackage())
            {
                var workbook = pck.Workbook;
                var worksheet = workbook.Worksheets.Add("Sheet1");
                var cells = worksheet.Cells;
                cells.LoadFromDataTable(datatable, true);
                
                var failedRow = 11;
                cells["C1"].Formula = "SUM(B2:B" + (failedRow - 1) + ")";
                cells["C1"].Calculate();
                Console.WriteLine(cells["C1"].Value);
            }
        }
