        private void button3_Click(object sender, EventArgs e)
        {
            // Open a doc file.
            Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document document = application.Documents.Open(@"e:\temp3.docx");
            object comment = "www.google.com" + Environment.NewLine;
            object missing = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word.Comment var = document.Comments.Add(document.Words[1], comment);
            try {
                document.Hyperlinks.Add(var.Range,ref comment,ref missing,ref missing,ref missing,ref missing);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
            document.Close();
            application.Quit();
        }
