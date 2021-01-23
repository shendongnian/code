    View code: Url.Action("Print", "Controller", new { id = "filename", area = "Area" }), new { @target = "_blank" }
      public ActionResult Print(id)
    {
        var cd = new ContentDisposition
        {
            FileName ="something.pdf",
            Inline = true 
        };
        Response.AppendHeader("Content-Disposition", cd.ToString());
        return File(reportResponse.Data.Document, MediaTypeNames.Application.Pdf);
    }`
