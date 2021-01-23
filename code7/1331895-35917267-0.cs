        public void Pdfs(string targetPdf, List<string> orderedList, string targetFolder, string spSite)
        {
            var f = 0;
            // we create a reader for a certain document
            var reader = new PdfReader(targetFolder + orderedList[f]);
            // we retrieve the total number of pages
            var n = reader.NumberOfPages;
            // step 1: creation of a document-object
            var document = new iTextSharp.text.Document(reader.GetPageSizeWithRotation(1));
            
            // step 2: we create a writer that listens to the document
            var writer = PdfWriter.GetInstance(document, new FileStream(targetPdf, FileMode.Create));
            // step 3: we open the document
            document.Open();
            var cb = writer.DirectContent;
            PdfImportedPage page;
            int rotation;
            // step 4: we add content
            var pdfPageName = 0;
            var pdfNewPageFlag = true;
            while (f < orderedList.Count)
            {
                var i = 0;
                while (i < n)
                {
                    i++;
                    document.SetPageSize(reader.GetPageSizeWithRotation(i));
                    document.NewPage();
                    if (pdfNewPageFlag)
                    {
                        var chapter = new iTextSharp.text.Chapter(orderedList[pdfPageName], pdfPageName + 1);
                        document.Add(chapter);
                        pdfNewPageFlag = false;
                        pdfPageName++;
                    }
                    page = writer.GetImportedPage(reader, i);
                    rotation = reader.GetPageRotation(i);
                    if (rotation == 90 || rotation == 270)
                    {
                        cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
                    }
                    else
                    {
                        cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                    }
                }
                reader.Close(); /////////////////////////
                f++;
                if (f >= orderedList.Count) continue;
                reader = new PdfReader(targetFolder + orderedList[f]);
                // we retrieve the total number of pages
                n = reader.NumberOfPages;
                pdfNewPageFlag = true;
                reader.Close(); /////////////////////////
            }
        }
