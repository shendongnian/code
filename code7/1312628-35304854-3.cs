        public bool TryCreate(string sourcePath, string destinationPath, out string errorMessage)
        {
            try
            {
                using (var _reader = new PdfReader(sourcePath))
                {
                    using (var _sourceDocument = new Document(_reader.GetPageSizeWithRotation(_pageFrom)))
                    {
                        using (var _fileStream =
                            new System.IO.FileStream(
                                Path.Combine(destinationPath, _fileName.ToLower().Contains(".pdf") ? _fileName : _fileName + ".pdf"),
                                System.IO.FileMode.Create))
                        {
                            using (_pdfCopy = new PdfCopy(_sourceDocument, _fileStream))
                            {
                                _sourceDocument.Open();
                                for (int i = _pageFrom; i <= _pageTo; i++)
                                {
                                    _importedPage = _pdfCopy.GetImportedPage(_reader, i);
                                    _pdfCopy.AddPage(_importedPage);
                                    _importedPage = null;
                                }
                            }
                        }
                    }
                }
                return true;
            }
        }
