    public class FtpUploader
    {
        private readonly string _root;
        public FtpUploader(string root)
        {
            _root = root;
            Credentials = new NetworkCredential("anonymous", "");
        }
        public NetworkCredential Credentials { get; set; }
        public async Task<bool> UploadAsync(string fileName, byte[] fileContents)
        {
            //var doc = Path.Combine(_root, fileName);
            var request = (FtpWebRequest) WebRequest.Create(_root);
            request.Method = WebRequestMethods.Ftp.UploadFileWithUniqueName;
            request.Credentials = Credentials;
            request.ContentLength = fileContents.Length;
            using (var requestStream = request.GetRequestStream())
            {
                await requestStream.WriteAsync(fileContents, 0, fileContents.Length);
            }
            using (var response = (FtpWebResponse) await request.GetResponseAsync())
            {
                Console.WriteLine("Upload File Complete, status {0}", response.StatusCode);
                Console.WriteLine(response.ResponseUri);
                if (response.StatusCode != FtpStatusCode.ClosingData) return false;
                try
                {
                    return await Rename(response.ResponseUri, fileName);
                }
                catch (WebException)
                {
                    return false;
                }
            }
        }
        private async Task<bool> Rename(Uri newUri, string newFileName)
        {
            var request = (FtpWebRequest) FtpWebRequest.Create(newUri);
            request.Proxy = null;
            request.Credentials = Credentials;
            request.Method = WebRequestMethods.Ftp.Rename;
            request.RenameTo = newFileName;
            using (var response = (FtpWebResponse) await request.GetResponseAsync())
            {
                Console.WriteLine("Rename File Complete, status {0}", response.StatusCode);
                Console.WriteLine(response.ResponseUri);
                return response.StatusCode == FtpStatusCode.FileActionOK;
            }
        }
    }
