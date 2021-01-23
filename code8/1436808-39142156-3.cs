    //firstly build up a key index to make the matching easier
    var t1Dic = new Dictionary<int,DataRow>();
    foreach(var row in table1.Rows)
    {
        t1Dic.Add(row[IDCol],row);
    }
    var t2Dic = new Dictionary<int,DataRow>();
    foreach(var row in table2.Rows)
    {
        t2Dic.Add(row[IDCol],row);
    }
    //next run though your linking table and add them to your results table
    var results = new DataTable();
    foreach(var row in table3.Rows)
    {
        var r = results.NewRow();
        r[YourColumnName1] = t1Dic[row[Id1Col][YourColumnName1];
        r[YourColumnName2] = t1Dic[row[Id1Col][YourColumnName2];
        r[YourColumnName3] = t2Dic[row[Id2Col][YourColumnName3];
        r[YourColumnName4] = t2Dic[row[Id2Col][YourColumnName4];
        r[YourColumnName5] = t2Dic[row[Id2Col][YourColumnName5];
    }
