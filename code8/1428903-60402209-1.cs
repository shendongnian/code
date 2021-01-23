    private IActionResult GetFile(int id)
    {
        var file = $"folder/{id}.pdf";
        // Response...
        var cd = new ContentDispositionHeaderValue("inline");
        cd.SetHttpFileName(file);
        Response.Headers[HeaderNames.ContentDisposition] = cd.ToString();
        Response.Headers.Add("X-Content-Type-Options", "nosniff");
        return File(System.IO.File.ReadAllBytes(file), "application/pdf");
    }
