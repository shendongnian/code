    namespace DownloadMethods
    {
        internal static class Downloads
        {
            public static void DownloadFile(object sender, object Response)
            {
                 string filePath = (sender as LinkButton).CommandArgument;
                 Response.ContentType = ContentType;
                 Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + Path.GetFileName(filePath));
                 Response.ContentType = "application/pdf";
                 Response.WriteFile(filePath);
                 Response.End();
             }
        }
    }
