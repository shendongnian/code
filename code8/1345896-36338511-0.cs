        List<string> powerPlantList = new List<string>
        {
            "test",
            "blah",
            "phase 6",
            "foo",
            "bar",
            "phase 6"
        };
        Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
        Excel.Visible = true;
        Workbook wkbk = Excel.Workbooks.Add();
        Worksheet sheet = wkbk.ActiveSheet;
        int initialRow = 4;
        for (int i = 0; i < powerPlantList.Count; i++)
        {
            string s = powerPlantList[i];
            string row = (i+ initialRow).ToString();
            if (s.Equals("phase 6"))
            {
                sheet.get_Range("B" + row, "O"+row).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
            // This is where you assign the color to the current row range
            }
            sheet.Cells[i + initialRow, 4] = s;
        }
