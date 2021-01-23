    public class UploadViewModel
    {
        CreateDirectoryModel createModel {get;set;}
    }
    public CreateDirectoryModel GetUploadFileFolders(CreateDirectoryModel model, string designId)
            {
                string customerSchema = SfsHelpers.StateHelper.GetSchema();
                TemplateLibraryEntry entry = GetTemplateLibraryEntry(designId, customerSchema);
                var path = Path.Combine(Server.MapPath("~/"), entry.FilePath);
                model.DesignId = designId;
                model.Directories = new List<string>();
                model.Directories.Add("/");
                model.Directories.AddRange(Directory.GetDirectories(path, "*", SearchOption.AllDirectories));
                for (int i = 1; i < model.Directories.Count; i++) {
                    model.Directories[i] = model.Directories[i].Substring(path.Length).Replace('\\', '/');
                }
                model.Directories.Sort();
                return model;
            }
