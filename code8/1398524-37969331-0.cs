    public ImageController : Controller
    {
        public FileStreamResult GetFile(string FileID)
        {
            return GetFile(new Guid(FileID));
        }
    
        public FileStreamResult GetFile(Guid FileID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add(@"ID", FileID);
                FileModel result = connection.Query<FileModel>("GetFile", dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                Stream stream = new MemoryStream(result.FileData);
                return new FileStreamResult(stream, result.FileType);
            }
        }
    }
