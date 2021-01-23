    public void CreateDir(string FolderName)
        {
            if (!FolderName.EndsWith("/"))
                FolderName += "/";
            var uploadStream = new MemoryStream(Encoding.UTF8.GetBytes(""));
            Storage.Objects.Insert(
                bucket: BucketName,
                stream: uploadStream,
                contentType: "application/x-directory",
                body: new Google.Apis.Storage.v1.Data.Object() { Name = FolderName}
                ).Upload();
        }
