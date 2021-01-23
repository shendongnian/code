    //// Second assembly (Without referencing System.Web):
    // An interface to link the assemblies without referencing to System.Web
    public interface IAttachmentFile {
        void SaveAs(string FileName);
    }
    ..
    ..
    // Define ChangeAttachment method
    public string ChangeAttachment(int userId, IAttachmentFile attachmentFile) { 
       string attachmentsFolderPath = ConfigurationManager.AppSettings["AttachmentsDirectory"];
       if (!Directory.Exists(attachmentsFolderPath)) {
            Directory.CreateDirectory(attachmentsFolderPath);
       }
       string fileTarget = Path.Combine(
            attachmentsFolderPath, 
            userId.ToString() + Path.GetExtension(file.FileName) 
       );
       if (File.Exists(fileTarget)) {
           File.Delete(fileTarget);
       }
       // This call leads to calling HttpPostedFileBase.SaveAs
       attachmentFile.SaveAs(fileTarget);
       return fileTarget;
    }
    //// First assembly (Referencing System.Web):
    // A wrapper class around HttpPostedFileBase to implement IAttachmentFile   
    class AttachmentFile : IAttachmentFile {
        private readonly HttpPostedFileBase httpPostedFile;
        public AttachmentFile(HttpPostedFileBase httpPostedFile) {
            if (httpPostedFile == null) {
                throw new ArgumentNullException("httpPostedFile");
            }
            this.httpPostedFile = httpPostedFile;
        }
        // Implement IAttachmentFile interface
        public SaveAs(string fileName) {
            this.httpPostedFile.SaveAs(fileName);
        }
    }
    ..
    ..
    // Create a wrapper around the HttpPostedFileBase object
    var attachmentFile = new AttachmentFile(httpPostedFile);
    // Call the ChangeAttachment method
    userManagerObject.ChangeAttachment(userId, attachmentFile);
