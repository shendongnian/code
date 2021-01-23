      table.Columns.Add("MixedData",typeof(DateTime));
        foreach (DataRow row in table.Rows)
        {
                        DateTime date = DateTime.ParseExact(row["Dates"].ToString() + " " + row["Hours"] + ":" + row["Minutes"], "MM/dd/yyyy H:mm", CultureInfo.InvariantCulture);
                        row["MixedData"] = date;
                        table.AcceptChanges();
       }
