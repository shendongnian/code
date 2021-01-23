    protected void Button1_Click(object sender, EventArgs e) 
    { 
        Response.ContentType = "Application/pdf"; 
        Response.AppendHeader("Content-Disposition", "attachment; filename=Your_Pdf_File.pdf"); 
        Response.TransmitFile(Server.MapPath("~/Files/Your_Pdf_File.pdf")); 
        Response.End(); 
    } 
