    public void Button1_Click(object sender, EventArgs e)
    {
    
        UniqueDirectory d = new UniqueDirectory();
        string dirPath = Request.MapPath("~/App_Data/");             // point to the directory of wispp on the server
        string wisppExe = Server.MapPath("~/App_Data/WisppNew.exe"); // point to the location of wispp on the server
        string fortranLib = Server.MapPath("~/App_Data/libf60rts.dll"); // point to the location of the fortran libray file on the server
        string excelTemplate = Server.MapPath("~/App_Data/WISPP_Template.xls");
        do
    
        {
            Guid guid = Guid.NewGuid();
            string uniqueSubFolderName = guid.ToString();
            string uniquePath = dirPath + uniqueSubFolderName;
    
        }
        while (Directory.Exists(d.uniquePath));
        Directory.CreateDirectory(d.uniquePath);
    
        //copy files to new unique directory
        string wisppUnique = Path.Combine(d.uniquePath, "WisppNew.exe");
        string fortranUnique = Path.Combine(d.uniquePath, "libf60rts.dll");
        string wisppGraphUnique = Path.Combine(d.uniquePath, "WISPPGRA");
        string excelUnique = Path.Combine(d.uniquePath, "WISPP_Template.xls");
        string excelOutput = Path.Combine(d.uniquePath, "WISPP_Output.xls");
        File.Copy(wisppExe, wisppUnique, true);
        File.Copy(fortranLib, fortranUnique, true);
        File.Copy(excelTemplate, excelUnique, true);
    
        //write data into excel        
        FileStream outputFile = new FileStream(excelOutput, FileMode.OpenOrCreate, FileAccess.Write);
        xssfworkbook.Write(outputFile);
        outputFile.Close();
    
        yourButton2.Click += (_sender, _e) =>
        {
            //excelOutput is still in scope
            FileInfo file = new FileInfo(excelOutput);
    
            if(file.Exists)
            {
                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "Application/x-msexcel";
                Response.Flush();
                Response.TransmitFile(file.FullName);
                Response.End();
            }
        };
    }
