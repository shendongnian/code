   DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("CurveNumber"), new DataColumn("ObjectId"), new DataColumn("Length"),
                                                   new DataColumn("Radius"), new DataColumn("Delta"), new DataColumn("Tangent") });
            dt.Rows.Add(new object[] { "1","0851ax","20","20","20","20" });
            dt.Rows.Add(new object[] { "2", "0852ab", "20", "20", "20", "20" });
            dt.Rows.Add(new object[] { "3", "0853ac", "25", "32", "12", "10" });
            dt.Rows.Add(new object[] { "4", "0854ad", "12", "31", "15", "20" });
            dt.Rows.Add(new object[] { "5", "0855ca", "20", "20", "20", "20" });
            dt.Rows.Add(new object[] { "6", "0856ad", "25", "32", "12", "10" });
            //Group by distinct 4 column
          var GroupBy4ColumnDistinct =  dt.Rows.Cast<DataRow>()
            .ToLookup(x => (Convert.ToString(x["Length"]) + Convert.ToString(x["Radius"]) + Convert.ToString(x["Delta"]) + Convert.ToString(x["Tangent"])).GetHashCode())
            .Select(x => new { key = x.Key, values = x.Select(y => Convert.ToString(y["CurveNumber"])).ToList() }).ToList();
            // add new table to dataset. dataset contain 3 table as shown in our sample output
          DataSet ds = new DataSet();
          foreach (var item in GroupBy4ColumnDistinct)
          {
              DataView dv = new DataView(dt);
              dv.RowFilter = " CurveNumber in ( " + string.Join(",", item.values) + " )";
              ds.Tables.Add(dv.ToTable());
          }</pre>
