        public FileResult DownloadPdf()
        {
            var filePath = Server.MapPath("~/Content/resume/BrentonBates_WebDev_Resume.pdf");
            var pdfFileBytes = FileHelper.GetBytesFromFile(filePath);
            return File(pdfFileBytes, "application/pdf", "Brenton Bates Business Application Developer.pdf");
        }
