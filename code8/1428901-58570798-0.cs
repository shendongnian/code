C#
public class InlineFileContentResult : FileContentResult
{
    public InlineFileContentResult(byte[] fileContents, string contentType)
        : base(fileContents, contentType)
    {
    }
    public override Task ExecuteResultAsync(ActionContext context)
    {
        var contentDispositionHeader = new ContentDisposition
        {
            FileName = FileDownloadName,
            Inline = true,
        };
        context.HttpContext.Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());
        FileDownloadName = null;
        return base.ExecuteResultAsync(context);
    }
}
The same can be done for the `FileStreamResult`:
C#
public class InlineFileStreamResult : FileStreamResult
{
    public InlineFileStreamResult(Stream fileStream, string contentType)
        : base(fileStream, contentType)
    {
    }
    public override Task ExecuteResultAsync(ActionContext context)
    {
        var contentDispositionHeader = new ContentDisposition
        {
            FileName = FileDownloadName,
            Inline = true,
        };
        context.HttpContext.Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());
        FileDownloadName = null;
        return base.ExecuteResultAsync(context);
    }
}
Instead of returning a `FileContentResult` or `FileStreamResult`, just return `InlineFileContentResult` or `InlineFileStreamResult`. F.e.:
C#
public IActionResult GetDocument(int id)
{
    var filename = $"folder/{id}.pdf";
    return new InlineFileContentResult(File.ReadAllBytes(filename), "application/pdf")
    {
        FileDownloadName = $"{id}.pdf"
    };
}
