        [HttpPost]
        public JsonResult FinaliseQuote(string quote)
        {
            var finalisedQuote = JsonConvert.DeserializeObject<FinalisedQuote>(System.Uri.UnescapeDataString(quote));
            // save the file and return an id...
        }
        public FileResult DownloadFile(int id)
        {
            var fs = System.IO.File.OpenRead(Server.MapPath(string.Format("~/Content/file{0}.pdf", id)));
            return File(fs, "application/octet-stream");
        }
