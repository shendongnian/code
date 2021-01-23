    using (Document docPDF = new Document(PageSize.LETTER, this.LM, this.RM, this.TM, this.BM))
    {
        this.writer = PdfWriter.GetInstance(docPDF, this.thePage.Response.OutputStream);
    
        docPDF.Open();
    
        for (int i = 0; i < elements.Count; i++)
        {
            docPDF.Add(elements[i]);
        }
    
        thePage.Response.HeaderEncoding = System.Text.Encoding.Default;
        thePage.Response.ContentType = "application/pdf; charset=utf-8";
        thePage.Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
        thePage.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        thePage.Response.Write(docPDF);
        thePage.Response.Flush();
        thePage.Response.End();
    }
