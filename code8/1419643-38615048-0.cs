    foreach (string Filename in this.Files)
            {
                LS_fileName = Path.GetFileName( Filename );
                    if (Path.GetExtension( Filename ) == ".doc" || Path.GetExtension( Filename ) == ".docx")
                    { 
                        // Convert to PDF:
                        wordDocument = appWord.Documents.Open(GlobalVar.TempFiles + LS_fileName);
                        LS_fileExtension = Path.GetExtension(Filename);
                        LS_fileName = LS_fileName.Replace( LS_fileExtension, LS_PDF );
                        i = 0;
                        foreach (string value in this.Files)
                        {
                            if (value == Filename)
                            {
                               this.Files[i] = this.Files[i].Replace(LS_fileExtension, LS_PDF);
                                break;
                            }
                            i++;
                            }
                            wordDocument.ExportAsFixedFormat(GlobalVar.TempFiles + LS_fileName, MSWORD.WdExportFormat.wdExportFormatPDF);
                           wordDocument.Close(missing, missing, missing);
                    }
    }
