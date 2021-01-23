            var workbook = new XLWorkbook("C:\\path to your xlsx file");
            //get the first worksheet
            var worksheet = workbook.Worksheets.Worksheet(1);
            var rng = worksheet.Range("A2","B7").AsTable();
            List<Tuple<string, string>> datas = rng.Rows().Select(row => Tuple.Create(row.Cell(1).Value.ToString(), row.Cell(2).Value.ToString())).ToList();
            var groups = datas.GroupBy(tuple => tuple.Item1);
            System.Data.DataTable t = new System.Data.DataTable();
            t.Columns.Add("Key");
            t.Columns.Add("Value");
            foreach (var grp in groups)
            {
                t.Rows.Add(grp.Key, grp.ToList().Select(tuple => tuple.Item2).Aggregate((a, b) => a + "," + b));
            }
