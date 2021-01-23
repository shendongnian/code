        public static IFormFile AsMockIFormFile(this FileInfo physicalFile)
        {
            var fileMock = new Mock<IFormFile>();
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            using (FileStream fs = physicalFile.OpenRead())
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    writer.WriteLine(temp.GetString(b));
                }
            }
            writer.Flush();
            ms.Position = 0;
            var fileName = physicalFile.Name;
            //Setup mock file using info from physical file
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);
            fileMock.Setup(m => m.OpenReadStream()).Returns(ms);
            fileMock.Setup(m => m.ContentDisposition).Returns(string.Format("inline; filename={0}", fileName));
            //...setup other members as needed
            return fileMock.Object;
        }
