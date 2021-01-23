	FixedClassBuilder cb = new FixedLengthClassBuilder("Customers");
	cb.AddField("BirthDate", 8, typeof(DateTime));
	cb.LastField.Converter.Kind = ConverterKind.Date;
	cb.LastField.Converter.Arg1 = "ddMMyyyy";
	cb.LastField.FieldNullValue = DateTime.Now;
			
	cb.AddField("Name", 3, typeof(string));
	
	cb.AddField("Age", 3, typeof(int));
	cb.LastField.TrimMode = TrimMode.Both;
			
	engine = new FileHelperEngine(cb.CreateRecordClass());
	DataTable dt = engine.ReadFileAsDT("testCustomers.txt");
