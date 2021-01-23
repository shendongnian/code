    var range = (Microsoft.Office.Interop.Excel.Range)excelCell;
    int textLength = range.Text.ToString().Length;
    for (int charCount = 1; charCount <= textLength; charCount++)
    {
      Characters character = range.Characters[charCount, 1];
      bool bold = (bool)character.Font.Bold;
      bool italic = (bool)character.Font.Italic;
      Color fontColor = System.Drawing.ColorTranslator.FromOle(character.Font.Color);
    }
