    string file=HttpContext.Current.Server.MapPath("/FOLDER1/FOLDER2/test.pdf");
    MemoryStream stream= new MemoryStream();
    HttpResponse response = HttpContext.Current.Response;            
    response.ClearContent();
    response.Clear();
    response.ContentType = "application/pdf";
    response.AddHeader("Content-Disposition", string.Format("attachment; filename=\"{0}.pdf\""));
    using (FileStream fs = new FileStream(file, FileMode.Create, System.IO.FileAccess.Write))
     {
         stream.WriteTo(fs);
     }
              
     response.Flush();
     response.End();
