    DataTable DtData = new DataTable();
    DtData.Columns.Add("ENCRYPTED_DATA", typeof(string));        
    for (Int64 i = 1; i <= 999999999; i++)
    {
        string Number = i.ToString("D9");
        string Encrypt = EncryptDecrypt.Encrypt(Number);
        DtData.Rows.Add(Encrypt);
        //vary this number depending on your performance testing and application needs
        if (i % 100000 == 0)
        {
            //instead of this 
            //GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            //commit changes and refresh your DataTable
            DoSomeDatabaseCommitHere(DtData);
            DtData = new DataTable();
        }
    }
