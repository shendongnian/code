    public static void AddUploadToXML(XDocument xdoc, int id, string fileHash, string fileName)
            {
                var singleUpload = new XElement("upload", new object[] {
                    new XAttribute("backupid", id),
                    new XElement("file", new object[] {new XAttribute("filename", fileName), fileHash})
                });
                xdoc.Root.Add(singleUpload);
            }
