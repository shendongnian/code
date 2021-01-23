    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    namespace ReleaseManager.BusinessObjects
    {
        public class RemoteDirInfo
        {
            public string Name { get; set; }
            public string ModifiedDate { get; set; }
        }
    
        public class RemoteFileInfo
        {
            public string Name { get; set; }
            public string ModifiedDate { get; set; }
            public long Size { get; set; }
        }
    
        public class RemoteInfo
        {
            public string Error { get; set; }
            public string CurrentDirectory { get; set; }
            public List<RemoteDirInfo> DirInfo { get; set; }
            public List<RemoteFileInfo> FileInfo { get; set; }
        }
    
    }
