    private static void DynaGenWordDoc(string fileName, Page page, WordprocessingDocument wdoc)
    {
        page.Response.ClearContent();
        page.Response.ClearHeaders();
        page.Response.ContentType = "application/vnd.ms-word";
        page.Response.AppendHeader("Content-Disposition", string.Format("attachment;filename={0}.docx", fileName));
    
        using (MemoryStream memoryStream = new MemoryStream())
        {
            wdoc.SaveAs(memoryStream);
            memoryStream.WriteTo(page.Response.OutputStream);
            memoryStream.Close();
        }
        page.Response.Flush();
        page.Response.End();
    }
