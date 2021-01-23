    Object oMissing = System.Reflection.Missing.Value;
    Object oTemplatePath = templatePath; // Path
    var wordApp = new Microsoft.Office.Interop.Word.Application();
    var wordDoc = new Microsoft.Office.Interop.Word.Document();
    wordDoc = wordApp.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);
    foreach (Field field in wordDoc.Fields)
    {
        var fieldText = field.Code.Text;
        var fieldName = fieldText.Substring(11).Split(new string[] { "\\" }, StringSplitOptions.None)[0].Trim();
        field.Select();
        if (fieldText.StartsWith(" MERGEFIELD"))
        {
            if (fieldName == "CustomTable")
            {
                var tab = wordDoc.Tables.Add(wordApp.Selection.Range, noOfColumns, noOfRows);
                tab.Cell(1, 1).Range.Text = "Some text";
                // ETC
            }
        }
    }
