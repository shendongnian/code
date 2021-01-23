    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using System.Collections;
    
    protected void Page_Load(object sender, EventArgs e)
        {
           PdfReader pdfReader = new PdfReader(Request.MapPath("~/editble.pdf"));
    
            // field names available in the subject PDF
            StringBuilder sb = new StringBuilder();
    
            foreach (DictionaryEntry de in pdfReader.AcroFields.Fields)
            {
                sb.Append(de.Key.ToString() + Environment.NewLine);
            }
            
        }
