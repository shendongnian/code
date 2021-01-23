    datatable.AsEnumerable()
        .Where(row => row["value"].ToString()=="xy")
        .ToList().ForEach(row => row["Collected"] = "xy_default");
    public void UpdateRow(datatable,value)
    {
         datatable.AsEnumerable()
            .Where(row => row["value"].ToString()==value)
            .ToList().ForEach(row => row["Collected"] = value + "_default");
    }
