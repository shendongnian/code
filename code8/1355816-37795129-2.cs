    if (FileUpload1.HasFile)
    {
        if (Path.GetExtension(FileUpload1.FileName) == ".xlsx")
        {
            Stream fs = FileUpload1.FileContent;
            ExcelPackage package = new ExcelPackage(fs);
            DataTable dt = new DataTable();
            dt= package.ToDataTable();
            List<DataRow> listOfRows = new List<DataRow>();
            listOfRows = dt.AsEnumerable().ToList();
                                                                                   
        }
    }
