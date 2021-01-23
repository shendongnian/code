        DataTable csvData = new DataTable();
        DataColumn idCol = new DataColumn("Id",typeof(int));
        //column should be already added into the column list of datatable before setting it as primary key
        csvData.Columns.Add(idCol);
        //set the primary key. Here you can add multiple columns as it is a array property. This fixes your error
        csvData.PrimaryKey = new[] { idCol };
        DataColumn[] primaryKeys;
        primaryKeys = csvData.PrimaryKey;
        //if you do not set the primary key the below count was earlier coming out to be zero.
        var count = primaryKeys.Length;
