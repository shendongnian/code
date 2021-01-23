        public class PdfHelper
        {
          public async Task PCLGenaratePdf(string path)
          {
            IFolder rootFolder = await FileSystem.Current.GetFolderFromPathAsync(path);
            IFolder folder = await rootFolder.CreateFolderAsync("folder", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync("file.pdf", CreationCollisionOption.ReplaceExisting);
            using (var fs = await file.OpenAsync(FileAccess.ReadAndWrite))
            {
                var document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();
                document.Add(new Paragraph("heloo everyone"));
                document.Close();
                writer.Close();
            }
         }
         public async Task<string> PCLReadFile(string path)
         {
            IFile file = await FileSystem.Current.GetFileFromPathAsync(path);
            return file.Path;
         }
        }
