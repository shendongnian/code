    public static class Extensions
    {
        public static void WritePdfDownload(this HttpResponse response, string filePath, string contentType)
        {
            response.ContentType = contentType;
            response.AppendHeader("Content-Disposition", "attachment;filename=\"" + Path.GetFileName(filePath));
            response.ContentType = "application/pdf";
            response.WriteFile(filePath);
            response.End();
        }
    }
