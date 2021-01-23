    static void Main(string[] args)
        {
            var encodedFile = File.ReadAllBytes(InPath);
            
            var signedData = new SignedCms();
            signedData.Decode(encodedFile);
            signedData.CheckSignature(true);
            if (!Verify(signedData))
                throw new Exception("No valid cert was found");
            var trueContent = new CmsSignedData(File.ReadAllBytes(InPath)).SignedContent;
            
            using (var str = new MemoryStream())
            {
                trueContent.Write(str);
                var zip = new ZipArchive(str, ZipArchiveMode.Read);
                zip.ExtractToDirectory(OutPath);
            }
            
            
        }
        static bool Verify(SignedCms signedData)
        {
            var myCetificates = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            myCetificates.Open(OpenFlags.ReadOnly);
            var certs = signedData.Certificates;
            return (from X509Certificate2 cert in certs
                select myCetificates.Certificates.Cast<X509Certificate2>()
                    .Any(crt => crt.Thumbprint == cert.Thumbprint))
                .Any();
            
        }   
