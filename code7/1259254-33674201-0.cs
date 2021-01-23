    public string ConnectionString(string FileName, string Header)
    {
        OleDbConnectionStringBuilder Builder = new OleDbConnectionStringBuilder();
        if (System.IO.Path.GetExtension(FileName).ToUpper() == ".XLS")
        {
            Builder.Provider = "Microsoft.Jet.OLEDB.4.0";
            Builder.Add("Extended Properties", string.Format("Excel 8.0;IMEX=1;HDR={0};", Header));
        }
        else
        {
            Builder.Provider = "Microsoft.ACE.OLEDB.12.0";
            Builder.Add("Extended Properties", string.Format("Excel 12.0;IMEX=1;HDR={0};", Header));
        }
    
        Builder.DataSource = FileName;
    
        return Builder.ConnectionString;
    }
