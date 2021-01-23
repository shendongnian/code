    byte[] arr = System.IO.File.ReadAllBytes(@"G:\test.rar");
    
    Response.ContentType = "application/x-rar-compressed";
    Response.AddHeader("content-disposition", "attachment;filename=Test.rar");
    Response.Buffer = true;
    Response.Clear();
    Response.BinaryWrite(arr);
    Response.End();
