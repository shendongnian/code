    private void button1_Click(object sender, EventArgs e)
    {
       Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();    
       Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(@"e:\testdoc1.docx");
       object missing = System.Reflection.Missing.Value;                        
       doc.Content.Text += textBox1.Text;
       app.Visible = true;    //Optional
       doc.Save();            
       this.Close();           
    }
