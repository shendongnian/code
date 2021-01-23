    DataTable results = new DataTable();
    results.Columns.Add("ID", typeof(int));
    results.Columns.Add("Proposition", typeof(string));
    results.Columns.Add("Consequent", typeof(string));
    
    var result1 = from arow in AtomicP.AsEnumerable()
    	join con in Consequent.AsEnumerable()
    	on arow.Field<int>("ID") equals con.Field<int>("ID")
    	select results.LoadDataRow(new object[]
    							   {
    								   arow.Field<int>("ID"),
    								   arow.Field<string>("Proposition"),
    								   con.Field<string>("Consequent")
    							   }, false);
