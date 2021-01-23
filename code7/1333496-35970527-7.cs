    void GetData()
    {
        //You load data from database and this data is just for test
        originalData = new DataTable();
        originalData.Columns.Add("Name", typeof(string));
        originalData.Columns.Add("Value", typeof(int));
        originalData.Rows.Add("a", 10);
        originalData.Rows.Add("b", 30);
        originalData.Rows.Add("c", 20);
    }
