	DelimitedClassBuilder cb = new DelimitedClassBuilder("Customers", ",");
	cb.IgnoreFirstLines = 1;
	cb.IgnoreEmptyLines = true;
	
	cb.AddField("BirthDate", typeof(DateTime));
	cb.LastField.TrimMode = TrimMode.Both;
	cb.LastField.FieldNullValue = DateTime.Today;
	cb.AddField("Name", typeof(string));
	cb.LastField.FieldQuoted = true;
	cb.LastField.QuoteChar = '"';
	cb.AddField("Age", typeof(int));
	
	engine = new FileHelperEngine(cb.CreateRecordClass());
	DataTable dt = engine.ReadFileAsDT("testCustomers.txt");
	
