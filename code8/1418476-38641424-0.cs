        private const string FieldDelimeter = " MERGEFIELD ";
        foreach (FieldCode field in doc.MainDocumentPart.RootElement.Descendants<FieldCode>())
        {
             var fieldNameStart = field.Text.LastIndexOf(FieldDelimeter, System.StringComparison.Ordinal);
             var fieldName = field.Text.Substring(fieldNameStart + FieldDelimeter.Length).Trim();
    
             foreach (Run run in doc.MainDocumentPart.Document.Descendants<Run>())
             {
                   foreach (Text txtFromRun in run.Descendants<Text>().Where(a => a.Text == "«" + fieldName + "»"))
                   {                            
                         txtFromRun.Text = "Replace what the merge field here";
                   }
             }
         } 
     
    
        doc.MainDocumentPart.Document.Save();
