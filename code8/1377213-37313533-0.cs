        public static void createBookmark(string sourcefilepart)
        {
            try
            {
                #region Try
                var pdfList = new DirectoryInfo(sourcefilepart).GetFiles("*.pdf");
                int pdfCount = pdfList.Length;
                for (int i = 0; i < pdfCount; i++)
                {
                    List<Dictionary<String, Object>> bookmarks = new List<Dictionary<String, Object>>();
                    Dictionary<String, Object> ht = new Dictionary<String, Object>();
                    //Get Existing PDF doc name
                    string sourceFileName = pdfList[i].Name.Substring(0, pdfList[i].Name.Length - 4);
                    //Define New PDF doc name
                    string newFileName = sourceFileName + "_new.pdf";
                    string newFilePathName = sourcefilepart + newFileName;
                    //Create Bookmark List                  
                    ht.Add("Title", sourceFileName);
                    bookmarks.Add(ht);
                    //Create a reder for PDF doc
                    PdfReader reader = new PdfReader(pdfList[i].FullName);
                    // Create a stamper
                    PdfStamper stamper = new PdfStamper(reader, new FileStream(newFilePathName, FileMode.Create));
                    //Show Bookmark
                    stamper.Outlines = bookmarks;
                    stamper.Writer.ExtraCatalog.Put(PdfName.PAGEMODE, PdfName.USEOUTLINES);
                    stamper.Close();
                    reader.Close();
                }
                #endregion Try
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
