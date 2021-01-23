    Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application { Visible = false };
    Microsoft.Office.Interop.Word.Document Doc = wordApp.Documents.Open("C:\\test.docx", ReadOnly: false, Visible: false);
    
    Doc.BuiltInDocumentProperties["Title"].Value = this.Title.Text;
    Doc.BuiltInDocumentProperties["Subject"].Value = this.Subject.Text;
    Doc.BuiltInDocumentProperties["Category"].Value = this.Category.Text;
    Doc.BuiltInDocumentProperties["Keywords"].Value = this.Keywords.Text;
    Doc.BuiltInDocumentProperties["Author"].Value = this.Author.Text;
    Doc.BuiltInDocumentProperties["Comments"].Value = this.Comments.Text;
