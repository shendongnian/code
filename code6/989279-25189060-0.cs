        public string GetFileContentsAsString(long revisionNumber)
        {
            return new StreamReader(GetFileContents(revisionNumber)).ReadToEnd();
        }
        private MemoryStream GetFileContents(long revisionNumber)
        {
            SvnRevision rev = new SvnRevision(revisionNumber);
            MemoryStream stream = new MemoryStream();
            using (SvnClient client = GetClient())
            {
                client.FileVersions(SvnTarget.FromUri(RemotePath), new SvnFileVersionsArgs() { Start = rev, End = rev }, (s, e) =>
                {
                    e.WriteTo(stream);
                });
            }
            stream.Position = 0;
            return stream;
        }
