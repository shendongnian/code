    public FilesController : BaseApiController 
    {
        [CustomAuthorize]
        public HttpResponseMessage Get(int fileID) 
        {
            return filesAccess.getFile(fileID, UserID);
        }
    }
