    Func<dynamic, Schema> make = 
        s => new Schema
        { 
            SchemaId = s.SchemaId, 
            Name = s.Name,
            XsdFile = new byte[length],
            MetadataFile = new byte[length],
            TemplateFile = new byte[length]
        };
		
	var result = (from s in db.Schemas
			     select new { s.SchemaId, s.Name })
                 .Select(n => make(n));
