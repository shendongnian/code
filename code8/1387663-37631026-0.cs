    public int DaysToEnd()
    {
        FileInfo hf = new FileInfo(_HideFilePath);
        if (hf.Exists == false)
        {
            MakeHideFile();
            return _DefDays;
        }
        return CheckHideFile();
    }  
