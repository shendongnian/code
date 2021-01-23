            PdfReader reader = new PdfReader(options.InputFile);
            List<int> pages;
            pages = new List<int>();
            
            int n_pages = reader.NumberOfPages;
            string basename = Path.GetFileNameWithoutExtension(options.InputFile);
            for (int pagenumber = 1; pagenumber <= n_pages; pagenumber++)
            {
                using (PdfReader page_reader = new PdfReader(options.InputFile))
                {
                    string filename;
                    Document document;
                    PdfCopy copy;
                    pages.Clear();
                    
                    filename = String.Format("{0}.{1}.pdf", basename, pagenumber);
                    document = new Document();
                    copy = new PdfCopy(document, new FileStream(filename, FileMode.Create));
                    
                    copy.SetMergeFields();
                    document.Open();
                    pages.Add(pagenumber);
                    copy.AddDocument(page_reader, pages);
                    
                    document.Close();
                }
            }
            return n_pages;
