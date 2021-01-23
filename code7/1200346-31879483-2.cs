    public static void TextToWord(string pWordDoc, Dictionary<string, string> pDictionaryMerge)
        {
            Object oMissing = System.Reflection.Missing.Value;
            Object oTrue = true;
            Object oFalse = false;
            Microsoft.Office.Interop.Word.Application oWord = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document oWordDoc = new Microsoft.Office.Interop.Word.Document();
            oWord.Visible = true;
            Object oTemplatePath = pWordDoc;
            oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);
            foreach (Microsoft.Office.Interop.Word.Field myMergeField in oWordDoc.Fields)
            {
                Microsoft.Office.Interop.Word.Range rngFieldCode = myMergeField.Code;
                String fieldText = rngFieldCode.Text;
                if (fieldText.StartsWith(" MERGEFIELD"))
                {
                    Int32 endMerge = fieldText.IndexOf("\\");
                    Int32 fieldNameLength = fieldText.Length - endMerge;
                    String fieldName = fieldText.Substring(11, endMerge - 11);
                    fieldName = fieldName.Trim();
                    foreach (var item in pDictionaryMerge)
                    {
                        if (fieldName == item.Key)
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText(item.Value);
                        }
                    }
                }
            }
        }
