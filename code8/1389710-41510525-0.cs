        private string GetBlobContainerSize(CloudBlobContainer contSrc)
        {
            var blobfiles = new List<string>();
            long blobfilesize = 0;    
            var blobblocks = new List<string>();
            long blobblocksize = 0;
            
            foreach (var g in contSrc.ListBlobs())
            {
                if (g.GetType() == typeof(CloudBlobDirectory))
                {
                   foreach (var file in ((CloudBlobDirectory)g).ListBlobs(true).Where(x => x as CloudBlockBlob != null))
                   {
                       blobfilesize += (file as CloudBlockBlob).Properties.Length;
                       blobfiles.Add(file.Uri.AbsoluteUri);
                  }
                    }
                    else if (g.GetType() == typeof(CloudBlockBlob))
                    {
                        blobblocksize += (g as CloudBlockBlob).Properties.Length;
                        blobblocks.Add(g.Uri.AbsoluteUri);
                    }
                }
            
                string res = string.Empty;
                if (blobblocksize > 0) res += "size: " + FormatSize(blobblocksize) + "; blocks: " + blobblocks.Count();
                if (!string.IsNullOrEmpty(res) && blobfilesize > 0) res += "; ";
                if (blobfilesize > 0) res += "size: " + FormatSize(blobfilesize) + "; files: " + blobfiles.Count();
                return res;
    }
    
    private string FormatSize(long len)
    {
        string[] sizes = { "B", "KB", "MB", "GB", "TB" };
        int order = 0;
        while (len >= 1024 && order < sizes.Length - 1)
        {
            order++;
            len = len / 1024;
        }
        return String.Format("{0:0.##} {1}", len, sizes[order]);
    }
