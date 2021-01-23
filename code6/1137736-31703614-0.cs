     void Main(string[] args)
        {
            var fileName = @"C:\temp\corrupt.xlsx";
            var newFileName = @"c:\temp\Fixed.xlsx";
            var newFileInfo = new FileInfo(newFileName);
    
            if (newFileInfo.Exists)
                newFileInfo.Delete();
    
            File.Copy(fileName, newFileName);
    
            WordprocessingDocument wDoc;
            try
            {
                using (wDoc = WordprocessingDocument.Open(newFileName, true))
                {
                    ProcessDocument(wDoc);
                }
            }
            catch (OpenXmlPackageException e)
            {
    			e.Dump();
                if (e.ToString().Contains("The specified package is not valid."))
                {
                    using (FileStream fs = new FileStream(newFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        UriFixer.FixInvalidUri(fs, brokenUri => FixUri(brokenUri));
                    }               
                }
            }
        }
    
        private static Uri FixUri(string brokenUri)
        {
    		brokenUri.Dump();
            return new Uri("http://broken-link/");
        }
    
        private static void ProcessDocument(WordprocessingDocument wDoc)
        {
            var elementCount = wDoc.MainDocumentPart.Document.Descendants().Count();
            Console.WriteLine(elementCount);
        }
    }
    
    public static class UriFixer
    {
        public static void FixInvalidUri(Stream fs, Func<string, Uri> invalidUriHandler)
        {
            XNamespace relNs = "http://schemas.openxmlformats.org/package/2006/relationships";
            using (ZipArchive za = new ZipArchive(fs, ZipArchiveMode.Update))
            {
                foreach (var entry in za.Entries.ToList())
                {
                    if (!entry.Name.EndsWith(".rels"))
                        continue;
                    bool replaceEntry = false;
                    XDocument entryXDoc = null;
                    using (var entryStream = entry.Open())
                    {
                        try
                        {
                            entryXDoc = XDocument.Load(entryStream);
                            if (entryXDoc.Root != null && entryXDoc.Root.Name.Namespace == relNs)
                            {
                                var urisToCheck = entryXDoc
                                    .Descendants(relNs + "Relationship")
                                    .Where(r => r.Attribute("TargetMode") != null && (string)r.Attribute("TargetMode") == "External");
                                foreach (var rel in urisToCheck)
                                {
                                    var target = (string)rel.Attribute("Target");
                                    if (target != null)
                                    {
                                        try
                                        {
                                            Uri uri = new Uri(target);
                                        }
                                        catch (UriFormatException)
                                        {
                                            Uri newUri = invalidUriHandler(target);
                                            rel.Attribute("Target").Value = newUri.ToString();
                                            replaceEntry = true;
                                        }
                                    }
                                }
                            }
                        }
                        catch (XmlException)
                        {
                            continue;
                        }
                    }
                    if (replaceEntry)
                    {
                        var fullName = entry.FullName;
                        entry.Delete();
                        var newEntry = za.CreateEntry(fullName);
                        using (StreamWriter writer = new StreamWriter(newEntry.Open()))
                        using (XmlWriter xmlWriter = XmlWriter.Create(writer))
                        {
                            entryXDoc.WriteTo(xmlWriter);
                        }
                    }
                }
            }
        }
