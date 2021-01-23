    void LoadDatabase()
    {
        DS.ReadXml(Server.MapPath("Customer.xml"), XmlReadMode.InferSchema);
        
        // check the number of tables here
        int count = ds.Tables.Count;
        System.Diagnostics.Debugger.Break();
        DS.Tables[(int)DBNum.Customer].PrimaryKey = new DataColumn[] {
                    DS.Tables[0].Columns["ID"] };
        CustomerRecordList();
    }
