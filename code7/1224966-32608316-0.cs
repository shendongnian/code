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
