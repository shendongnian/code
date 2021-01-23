    static void Main(string[] args)
        {
            
            const string zipPath = @"C:\temp\file.zip.p7";
            var signedData = new CmsSignedData(File.ReadAllBytes(zipPath));
            
            var content = signedData.SignedContent;
            using (var str = new FileStream("newzip.zip", FileMode.CreateNew))
            {
                content.Write(str);
                str.Flush();
            }
            
        }
