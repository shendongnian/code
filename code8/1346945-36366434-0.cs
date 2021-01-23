        private bool CheckForNewPage(PdfCopy copy, ref PdfImportedPage page, ref PdfCopy.PageStamp stamp, ref PdfReader templateReader, ColumnText ct)
        {
            if (ColumnText.HasMoreText(ct.Go()))
            {
                //Write current page
                stamp.AlterContents();
                copy.AddPage(page);
                //Start a new page
                ct.SetSimpleColumn(36, 36, 559, 778);
                templateReader = new PdfReader("template.pdf");
                page = copy.GetImportedPage(templateReader, 1);
                stamp = copy.CreatePageStamp(page);
                ct.Canvas = stamp.GetOverContent();
                ct.Go();
                return true;
            }
            return false;
        }
