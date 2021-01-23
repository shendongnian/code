        void InsertToFile(string inputString) // function to insert string to word doc
        {
            object missing = System.Reflection.Missing.Value;
            object readOnly = false;
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = app.Documents.Open("C:\\Users\\SS5014874\\Desktop\\JohnH.docx", ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);                        
            app.ActiveDocument.Characters.Last.Select();
            app.Selection.Collapse();
            app.Selection.TypeText(inputString.ToString());            
            app.ActiveDocument.Save();
            app.ActiveDocument.Close();
            app.Quit();
            MessageBox.Show("Inserted");
        }       
