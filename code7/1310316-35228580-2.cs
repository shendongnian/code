    var xlApp = new Application();
    var workbook = xlApp.Workbooks.Open("c:\\temp\\exceltest.xlsx");
    Worksheet sheet = workbook.Sheets[1];
    Range cell = sheet.Cells[1, 1]; // get first cell as an example
    int textLength = range.Text.ToString().Length;
    for (int charCount = 1; charCount <= textLength; charCount++)
    {
      Characters character = cell.Characters[charCount, 1];
      bool bold = (bool)character.Font.Bold;
      bool italic = (bool)character.Font.Italic;
      Color fontColor = System.Drawing.ColorTranslator.FromOle((int)character.Font.Color);
    }
