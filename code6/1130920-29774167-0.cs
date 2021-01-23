    DataTable tblResult = new DataTable();
    tblResult.Columns.Add("ID"); 
    tblResult.Columns.Add("userfullname1"); 
    tblResult.Columns.Add("userfullname2"); 
    tblResult.Columns.Add("userfullname3"); 
    tblResult.Columns.Add("Work");
    var query = from r1 in datatable1.AsEnumerable()
                from r2 in datatable2.AsEnumerable()
                let id = r1.Field<int>("ID")
                let userID1 = r2.Field<int>("userID1")
                let userID2 = r2.Field<int>("userID2")
                let userID3 = r2.Field<int>("userID3")
                where id == userID1 && id == userID2 && id == userID3
                select new { r1, r2, id, userID1, userID2, userID3 };
    foreach (var x in query)
    {
        DataRow row = tblResult.Rows.Add();
        string firstName = x.r1.Field<string>("firstname");
        string lastName = x.r1.Field<string>("lastname");
        string userfullname1 = string.Format("{0} {1} {2}", firstName, lastName, x.userID1);
        string userfullname2 = string.Format("{0} {1} {2}", firstName, lastName, x.userID2);
        string userfullname3 = string.Format("{0} {1} {2}", firstName, lastName, x.userID3);
        row.SetField("ID", x.id);
        row.SetField("userfullname1", userfullname1);
        row.SetField("userfullname2", userfullname2);
        row.SetField("userfullname3", userfullname3);
        row.SetField("Work", x.r2.Field<string>("Work"));
    }
