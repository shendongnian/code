	xmlDoc.Root.Add(
		new XElement("Temprature",
			new[]
			{
				new XElement("Temp_F",
					!string.IsNullOrEmpty(medicationEntity.Value) ? medicationEntity.Value : null),
				new XElement("Temp_C",
					!string.IsNullOrEmpty(medicationEntity.Value)
						? ((Convert.ToInt64(medicationEntity.Value) - 32)/1.80).ToString()
						: null),
				new XElement("vHour",
					!string.IsNullOrEmpty(medicationEntity.Time)
						? (DateTime.Parse(medicationEntity.Time).Hour).ToString()
						: null),
				new XElement("vMin",
					!string.IsNullOrEmpty(medicationEntity.Time)
						? (DateTime.Parse(medicationEntity.Time).Minute).ToString()
						: null),
				new XElement("vEvent",
					!string.IsNullOrEmpty(medicationEntity.Time)
						? DateTime.Parse(medicationEntity.Time).Hour > 11 ? "pm" : "am"
						: null)
			}.Where(w => !string.IsNullOrWhiteSpace(w.Value)),
			new XElement("Temp_Method", medicationEntity.Method),
			new XElement("Vsdate", vsDate)
			));
