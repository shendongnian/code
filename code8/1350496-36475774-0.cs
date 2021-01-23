        Application excelApp = new Application();
        excelApp.Workbooks.Add();
        // single worksheet
        _Worksheet workSheet = excelApp.ActiveSheet;
        string Green = "Green";
        string Red = "Red";
        for (int start = 0; start < 10; start++)
        {
            Range ColorMeMine = workSheet.Cells[1, (start + 1)];
            ColorMeMine.Value = string.Format("{0} {1}", Green, Red);
            ColorMeMine.Characters[0, Green.Length].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
            ColorMeMine.Characters[Green.Length + 1, Green.Length + 1 + Red.Length].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
        }
