    Response.ClearContent(); 
    Response.ClearHeaders(); 
    Response.BufferOutput = true; 
    Response.ContentType = "application/excel"; 
    Response.AddHeader("Content-Disposition", "attachment; filename=Reliquat.xslx"); 
    Response.Write(tab); 
    Response.Flush(); 
    Response.Close(); 
    Response.End();
