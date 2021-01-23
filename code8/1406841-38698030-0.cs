     public byte[] DocumentGenerator(String templatePath)
        {
            byte[] buffer;
            using (MemoryStream stream = new MemoryStream())
            {
                buffer = System.IO.File.ReadAllBytes(templatePath);
                stream.Write(buffer, 0, buffer.Length);
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(stream, true))
                {
                   //Get list bookmarks
                    var listBookMarks = wordDocument.MainDocumentPart.Document.Descendants<BookmarkStart>().ToList();
                    //Get list Merge Fields
                    var listMergeFields = wordDocument.MainDocumentPart.Document.Descendants<FieldCode>().ToList();
                    //Do some code
                    wordDocument.Close();
                }
                buffer = stream.ToArray();
            }
            return buffer;
        }
