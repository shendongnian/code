    private static DataRow CreateDataRow(DataTable table, string pirateId, string name,
        string shipClass, string avastyMast)
    {
        var row = table.NewRow();
        // Make sure the column names match those in the table!
        row["PirateId"] = pirateId;
        row["Name"] = name;
        row["ShipClass"] = shipClass;
        row["AvastyMast"] = avastyMast;
        return row;
    }
