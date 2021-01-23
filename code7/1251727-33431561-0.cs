    public ActionResult DownloadSomeFile()
        {
            using (var ms = new MemoryStream())
            {
                var response = GetMyPdfAsStream(); // implement this yourself
                if (response is StreamContent)
                {
                    var responseContent = response as StreamContent;
                    await responseContent.CopyToAsync(ms);
                    byte[] file = ms.ToArray();
                    MemoryStream output = new MemoryStream();
                    output.Write(file, 0, file.Length);
                    output.Position = 0;
                    return new FileStreamResult(output, "application/pdf") { FileDownloadName = fileName };
                }
                else
                {
                    return Content("Something went wrong: " + response.ReasonPhrase);
                }
                return null;
            }
        }
