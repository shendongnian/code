    public class FileAttachmentService : IFileAttachmentService
    {
        private static readonly string _folder = "~/Attachments/";
        public Attachments Save(HttpPostedFileBase file)
        {
            if (file == null)
                return new Attachments();
            var savePath = GenerateUniqueFileName(_folder + Path.GetFileName(file.FileName));
            file.SaveAs(HttpContext.Current.Server.MapPath(savePath));
            return new Attachments
            {
                ContentType = file.ContentType,
                Name = Path.GetFileName(file.FileName),
                Path = savePath
            };
        }
        private string GenerateUniqueFileName(string basedOn)
        {
            if (string.IsNullOrWhiteSpace(basedOn))
                throw new ArgumentNullException("basedOn");
            return (Path.GetDirectoryName(basedOn)
                + "\\"
                + Path.GetFileNameWithoutExtension(basedOn)
                + "."
                + Path.GetRandomFileName()
                + Path.GetExtension(basedOn))
                .Replace('\\', '/');
        }
    }
