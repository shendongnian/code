    public void closeDocument(Word.Document doc)
            {
                object missing = Missing.Value;
                object dontsave = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
                doc.Close(ref dontsave, ref missing, ref missing);
                
            }
