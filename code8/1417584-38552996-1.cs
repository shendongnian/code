    public static async Task<string> UploadFile(string folder, string fileName, string fileUri)
    {
        using (var mem = new FileStream(fileUri, FileMode.Open, FileAccess.Read))
        {
            FileMetadata updated = await dbx.Files.UploadAsync(
            folder + "/" + fileName,
            WriteMode.Overwrite.Instance,
            body: mem);
            var arg1 = new Dropbox.Api.Sharing.CreateSharedLinkWithSettingsArg(folder + "/" + fileName);
            var share = await dbx.Sharing.CreateSharedLinkWithSettingsAsync(arg1);
            return share.Url;
        }
    }
