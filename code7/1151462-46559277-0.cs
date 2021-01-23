            Microsoft.Office.Interop.Word.Application wordApplication = null;
            Microsoft.Office.Interop.Word.Documents wordDocuments = null;
            Microsoft.Office.Interop.Word.Document wordDocument = null;            
            try
            {
                wordApplication = new Microsoft.Office.Interop.Word.Application();
                wordDocuments = wordApplication.Documents;
                wordDocument = wordDocuments.Open(documentPath);
                foreach(Microsoft.Office.Interop.Word.InlineShape inlineShape in wordDocument.InlineShapes)
                {
                    if (inlineShape.Title.Contains(imageTitleCriteria)) inlineShape.Delete();
                }
                
            }
            catch(Exception)
            {
            }
            finally
            {
                if (wordDocument != null)
                {
                    wordDocument.Close(false);
                    Marshal.ReleaseComObject(wordDocument);
                }
                if (wordDocuments != null)
                {
                    wordDocuments.Close(false);
                    Marshal.ReleaseComObject(wordDocuments);
                }
                if (wordApplication != null)
                {
                    wordApplication.Quit(false);
                    Marshal.ReleaseComObject(wordApplication);
                }
            }
