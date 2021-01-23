        NPOI.SS.UserModel.IWorkbook hssfworkbook;
        bool InitializeWorkbook(string path)
        {
            try
            {
                if (path.ToLower().EndsWith(".xlsx"))
                {
                    FileStream file1 = File.OpenRead(path);
                    hssfworkbook = new XSSFWorkbook(file1);
                }
                else
                {
                    //read the template via FileStream, it is suggested to use FileAccess.Read to prevent file lock.
                    //book1.xls is an Excel-2007-generated file, so some new unknown BIFF records are added. 
                    using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        hssfworkbook = new HSSFWorkbook(file);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
