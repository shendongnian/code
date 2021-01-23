            List<Foo> fooList = new List<Foo>();
            Foo tempFoo = new Foo();
            tempFoo.Column1 = new DateTime(2000, 01, 01);
            tempFoo.Column2 = "one";
            tempFoo.Column3 = 1;
            tempFoo.Column4 = true;
            fooList.Add(tempFoo);
            tempFoo = new Foo();
            tempFoo.Column1 = new DateTime(2000, 02, 02);
            tempFoo.Column2 = "two";
            tempFoo.Column3 = 2;
            tempFoo.Column4 = false;
            fooList.Add(tempFoo);
            tempFoo = new Foo();
            tempFoo.Column1 = new DateTime(2000, 03, 03);
            tempFoo.Column2 = "three";
            tempFoo.Column3 = 3;
            tempFoo.Column4 = true;
            fooList.Add(tempFoo);
            DataSet ds = new DataSet();
            var workbook = new XLWorkbook();
            workbook.AddWorksheet("sheetName");
            var ws = workbook.Worksheet("sheetName");
            int row = 1;
            foreach (Foo f in fooList)
            {
                string rowString = row.ToString();
                ws.Cell("A" + rowString).Value = f.Column1;
                ws.Cell("B" + rowString).Value = f.Column2;
                ws.Cell("C" + rowString).Value = f.Column3;
                ws.Cell("D" + rowString).Value = f.Column4;
                row++;
            }
            workbook.SaveAs("yourExcel.xlsx");
