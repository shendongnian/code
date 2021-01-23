    public static void createExcelFile(String filepath, String sheetName)
            {
                try
                {
                    using (FileStream stream = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite))
                    {
                           workBook = new HSSFWorkbook();
                           workSheet = workBook.CreateSheet(sheetName);
                           workBook.Write(stream);
                           stream.Close();
                    }
                }
                catch (Exception e) {
                    Console.WriteLine("Unable to Create File. Exception is : " + e);
                }
            }
    
            public static void setExcelFile(string filepath, string sheetName)
            {
                try
                {
                    Console.WriteLine("File Path is : " + filepath);
                    workBook = WorkbookFactory.Create(new FileStream(
                                   Path.GetFullPath(filepath),
                                   FileMode.Open, FileAccess.Read,
                                   FileShare.ReadWrite));
    
                    workSheet = workBook.GetSheet(sheetName);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unable to Load File. Exception is : " + e);
                }
            }
