    Word.Range rngDocBody = doc.Content;
    Word.Range rngField = null;
    rngDocBody.TextRetrievalMode.IncludeFieldCodes = true;
    foreach (Word.Field field in rngDocBody.Fields)
    {
            //Search for a "Name" or "Gender" field
            if (field.Type == Word.WdFieldType.wdFieldMergeField)
            {
                rngField = field.Result;
                //field.Select();
                //doc.Application.Selection.TypeText("X");
                field.Delete();
                rngField.Text = "X";
               // break;
            }
    }
