      Workbook workbook = new Workbook("F:\\test.xlsx");
            Worksheet s = workbook.Worksheets.First();
            Cell c = s.Cells.FirstCell;
            if (c != null)
            {
                Style st = c.GetStyle();
                st.Font.IsBold = true;
                c.SetStyle(st);
            }
            workbook.Save("F:\\test1.xlsx");
