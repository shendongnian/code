    public static void TextToWord(string pWordDoc, string pMergeField, string pValue)
    {
        Object oMissing = System.Reflection.Missing.Value;
        Object oTrue = true;
        Object oFalse = false;
        Word.Application oWord = new Word.Application();
        Word.Document oWordDoc = new Word.Document();
        oWord.Visible = true;
        Object oTemplatePath = pWordDoc;
        oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);
        foreach (Word.Field myMergeField in oWordDoc.Fields)
        {
            Word.Range rngFieldCode = myMergeField.Code;
            String fieldText = rngFieldCode.Text;
            if (fieldText.StartsWith(" MERGEFIELD"))
            {
                Int32 endMerge = fieldText.IndexOf("\\");
                Int32 fieldNameLength = fieldText.Length - endMerge;
                String fieldName = fieldText.Substring(11, endMerge - 11);
                fieldName = fieldName.Trim();
                if (fieldName == pMergeField)
                {
                    myMergeField.Select();
                    oWord.Selection.TypeText(pValue);
                }
            }
        }
    }
