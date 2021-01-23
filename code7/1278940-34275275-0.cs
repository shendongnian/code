            var rnd = new Random();
            var pkg = new ExcelPackage();
            var ws = pkg.Workbook.Worksheets.Add("Test");
            var blist = new List<bool>();
            for(int i=0; i < 20;i++) {
                blist.Add(rnd.NextDouble() > .5 ? true : false);
            }
            ws.Cells["A5"].LoadFromCollection(blist, true);
            pkg.SaveAs(new FileInfo(@"c:\tmp\bool.xlsx"));
