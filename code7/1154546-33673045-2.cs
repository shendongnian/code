        public void Convert(string fileNames) {
            int pageCount = 0;
            iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(fileNames);
            pageCount = reader.NumberOfPages;
            string ext = System.IO.Path.GetExtension(fileNames);
    
            //string[] outfiles = new string[pageCount];
            //Excel.Application app = new Excel.Application();
            //app.Workbooks.Add("");
            CSVExtractor extractor = new CSVExtractor();
            //string outfilePDF1 = fileNames.Replace((System.IO.Path.GetFileName(fileNames)), (System.IO.Path.GetFileName(fileNames).Replace(".pdf", "") + "_rez" + ".csv"));
            string outfilePDFExcel1 = fileNames.Replace((System.IO.Path.GetFileName(fileNames)),
                (System.IO.Path.GetFileName(fileNames).Replace(".pdf", "") + "_rez" + ".xls"));
            extractor.RegistrationName = "demo";
            extractor.RegistrationKey = "demo";
    
            string folderName = @"C:\Users\Dafina\Desktop\PDF_EditProject\PDF_EditProject\PDFs";
            string pathString = System.IO.Path.Combine(folderName, System.IO.Path.GetFileName(fileNames).Replace(".pdf", "")) + "-CSVs";
            System.IO.Directory.CreateDirectory(pathString);
            for (int i = 0; i < pageCount; i++)
            {
                string outfilePDF = fileNames.Replace((System.IO.Path.GetFileName(fileNames)),
                    (System.IO.Path.GetFileName(fileNames).Replace(".pdf", "") + "_" + (i + 1).ToString()) + ext);
                extractor.LoadDocumentFromFile(outfilePDF);
                //string outfile = fileNames.Replace((System.IO.Path.GetFileName(fileNames)),
                //    (System.IO.Path.GetFileName(fileNames).Replace(".pdf", "") + "_" + (i + 1).ToString()) + ".csv");
                string outfile = fileNames.Replace((System.IO.Path.GetFileName(fileNames)),
                    (System.IO.Path.GetFileName(fileNames).Replace(".pdf", "") + "-CSVs\\" + "Sheet_" + (i + 1).ToString()) + ".csv");
                extractor.SaveCSVToFile(outfile);
            }
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
    
            if (xlApp == null)
            {
                Console.WriteLine("Excel is not properly installed!!");
                return;
            }
    
            Excel.Workbook xlWorkBook;
    
    
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            string[] cvsFiles = Directory.GetFiles(pathString);
            Array.Sort(cvsFiles, new AlphanumComparatorFast());
    
            //string[] lista = new string[pageCount];
            //for (int t = 0; t < pageCount; t++)
            //{
            //    lista[t] = cvsFiles[t];           
            //}
    
            //Array.Sort(lista, new AlphanumComparatorFast());
    
    
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            for (int i = 0; i < cvsFiles.Length; i++)
            {
                int sheet = i + 1;
                xlWorkSheet = xlWorkBook.Sheets[sheet];
    
                if (i < cvsFiles.Length - 1)
                {
                    xlWorkBook.Worksheets.Add(Type.Missing, xlWorkSheet, Type.Missing, Type.Missing);
                }
    
    
                int sheetRow = 1;
                Encoding objEncoding = Encoding.Default;
                StreamReader readerd = new StreamReader(File.OpenRead(cvsFiles[i]));
                int ColumLength = 0;
                while (!readerd.EndOfStream)
                {
                    string line = readerd.ReadLine();
                    Console.WriteLine(line);
                    try
                    {
                        string[] columns = line.Split((new char[] { '\"' }));
    
                        for (int col = 0; col < columns.Length; col++)
                        {
                            if (ColumLength < columns.Length)
                            {
                                ColumLength = columns.Length;
                            }
                            if (col % 2 == 0)
                            {
                               
                            }
                            else if (columns[col] == "")
                            {
                               
                            }
                            else
                            {
                                xlWorkSheet.Cells[sheetRow, col + 1] = columns[col].Replace("\"", "");
                            }
                        }
                        sheetRow++;
                    }
                    catch (Exception e)
                    {
                        string msg = e.Message;
                    }
                }
    
                int k = 1;
                for (int s = 1; s <= ColumLength; s++)
                {
                    xlWorkSheet.Columns[k].Delete();
                    k++;
                }
    
    
    
                releaseObject(xlWorkSheet);
                readerd.Close();
            }
    
            xlWorkBook.SaveAs(outfilePDFExcel1, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
    
            xlApp.Quit();
    
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
    
            var dir = new DirectoryInfo(pathString);
            dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
            dir.Delete(true);
    
    }
