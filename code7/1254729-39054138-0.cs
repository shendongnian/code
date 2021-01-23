    public string generatePDF()
    {
        string HTML = "";   ///Create a html as per our need
        HTML += "<html>";
                 ///Update the html here
        HTML += "</html>";
    
        string pdf_file_path = Request.PhysicalApplicationPath +   "pdf\\quotations\\";    //getting physical application path for save the pdf
        string final_name = "Here pdf name";
        PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(pdf_file_path + final_name, FileMode.Create));
        wri.PageEvent = new ITextEvents();
        doc.Open();
        var content = wri.DirectContent;
        content.MoveTo(28, doc.PageSize.Height - 150);
        content.LineTo(28, doc.PageSize.Height - 200);
        content.Stroke();      //generating line
        content.MoveTo(573, doc.PageSize.Height - 150);
        content.LineTo(573, doc.PageSize.Height - 200);
        content.Stroke();
        HTMLWorker htmlworker = new HTMLWorker(doc);   //here we have to pass created instance of pdfWritter
        htmlworker.SetStyleSheet(style);
        htmlworker.Parse(new StringReader(HTML));  ///here pass the created HTML what we have need in the PDF 
        doc.NewPage();
        doc.Close();
        
        var json = JsonConvert.SerializeObject(final_name, Newtonsoft.Json.Formatting.Indented, common.JsonSerializeSettings());
        return json;     // retruning the file name 
        Response.Write(doc);
        Response.End();
    }  
