    var fileName = Path.GetFileName( filePath );
    HttpResponseBase.Response.ClearContent();
    this.Response.ClearHeaders();
    this.Response.ContentType = type;
    this.Response.AppendHeader( "Content-Disposition", "attachment; filename=" + fileName );
    this.Response.BinaryWrite( System.IO.File.ReadAllBytes( filePath ) );
    this.Response.End();
