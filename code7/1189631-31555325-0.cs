	StringBuilder sb = new StringBuilder();
	StringWriter sw = new StringWriter(sb);
	
	using (JsonWriter writer = new JsonTextWriter(sw))
	{
	    writer.Formatting = Formatting.Indented;
	    writer.WriteStartObject();
	    writer.WritePropertyName("Building One");
	    writer.WriteStartObject();
	    writer.WritePropertyName("Floor A");
	    writer.WriteStartObject();
	    writer.WritePropertyName("A");
	    writer.WriteStartObject();
	    writer.WritePropertyName("Occupied");
	    writer.WriteValue("2");
	    writer.WritePropertyName("Vacant");
	    writer.WriteValue("2");
	    writer.WriteEnd();
	    writer.WritePropertyName("B");
	    writer.WriteStartObject();
	    writer.WritePropertyName("Occupied");
	    writer.WriteValue("0");
	    writer.WritePropertyName("Vacant");
	    writer.WriteValue("4");
	    writer.WriteEnd();
	    writer.WriteEndObject();
	}
