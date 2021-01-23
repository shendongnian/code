      Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            string fileName = @"C:\folder\document.docx";
            Document wordDoc = wordApp.Documents.Open(fileName);
            Microsoft.Office.Interop.Word.Range rng = wordDoc.Range();
            foreach (Microsoft.Office.Interop.Word.Range word in rng.Words)
            {
                if (word.Bold == -1)
                {
                    //Do wathever you want with the bold text                    
                }
                else if (word.Italic == -1)
                {
                    //Do wathever you want with the italic text
                }
                else if ( ((WdUnderline) word.Underline) == WdUnderline.wdUnderlineSingle)
                {
                    //Do wathever you want with the underline text
                }
            }
            wordApp.Documents.Close();
            wordApp.Quit();
