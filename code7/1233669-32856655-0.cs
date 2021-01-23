    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string fileName = ListBox1.SelectedValue;
        byte[] fileBytes = System.IO.File.ReadAllBytes(fileName);
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        context.Response.Clear();
        context.Response.ClearHeaders();
        context.Response.ClearContent();
        context.Response.AppendHeader("content-length", fileBytes.Length.ToString());
        context.Response.ContentType = "application/pdf";
        context.Response.AppendHeader("content-disposition", "attachment; filename=" + fileName);
        context.Response.BinaryWrite(fileBytes);
        context.ApplicationInstance.CompleteRequest();
    }
