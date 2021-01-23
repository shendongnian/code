    var dt = AppUtils.db.GetDataTable("dbo.RankSelectChart", view); // stopred procedure and getting datatable 
	var pColumns = dt.Columns.Cast<DataColumn>()
        .Where(c => c.ColumnName.StartsWith("p"));
    var result = pColumns
        	.Select(p => dt.AsEnumerable().ToDictionary(
					i => i.Field<DateTime>("lastDatetime"),
					i => i.Field<DateTime>(p.ColumnName)))
			.ToList();
