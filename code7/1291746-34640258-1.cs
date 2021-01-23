    public void GenerateDuckbilledPlatypusRpt()
    {
        try
        {
            InitializeExcelObjects();
            . . . // all the Excel generation code goes here
        }
        finally
        {
            DeinitializeExcelObjects();
        }
    }
