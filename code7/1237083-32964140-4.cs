    foreach (var x in query)
    {
        DataRow addedRow = Table4.Rows.Add();
        addedRow.SetField("ID", x.ID);
        addedRow.SetField("ParamX", x.ParamX);
        addedRow.SetField("ParamA", x.ParamA);
        addedRow.SetField("ParamB", x.ParamB);
        addedRow.SetField("ParamC", x.ParamC);
    }
