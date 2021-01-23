            //Microsoft.Office.Interop.Word.ApplicationClass wordObject = new Microsoft.Office.Interop.Word.ApplicationClass();
            Microsoft.Office.Interop.Word.Application wordObject = new Microsoft.Office.Interop.Word.Application();
            object File = PathString; 
            object nullobject = System.Reflection.Missing.Value; 
            Microsoft.Office.Interop.Word.Application wordobject = new Microsoft.Office.Interop.Word.Application();
            wordobject.DisplayAlerts = Microsoft.Office.Interop.Word.WdAlertLevel.wdAlertsNone; 
            Microsoft.Office.Interop.Word._Document docs = wordObject.Documents.Open(ref File, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject); 
            docs.ActiveWindow.Selection.WholeStory();
            docs.ActiveWindow.Selection.Copy();
            frmdoc.rtbDoc.Paste();
            docs.Close(ref nullobject, ref nullobject, ref nullobject);
            wordobject.Quit(ref nullobject, ref nullobject, ref nullobject);
        }
       private void OpenFile(string FilePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(FilePath))
                {
                       ImportWord(FilePath);
                }
                else
                {
                    MessageBox.Show("Cannot open a document which not exist.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
