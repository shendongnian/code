    var xmlDoc = new XDocument();
    xmlDoc.Add(new XElement("root"));
    if (prescriptionTemperatureList != null && prescriptionTemperatureList.Count > 0)
    {
    	foreach (var medicationEntity in prescriptionTemperatureList)
    	{
    		if (xmlDoc.Root != null)
    		{
    			var temperature = new XElement("Temprature");
    			if(!string.IsNullOrEmpty(medicationEntity.Value))
    				temperature.Add(new XElement("Temp_F", medicationEntity.Value));
    			if(!string.IsNullOrEmpty(medicationEntity.Value))
    				temperature.Add(new XElement("Temp_C", ((Convert.ToInt64(medicationEntity.Value)-32)/1.80).ToString()));
    			if(!string.IsNullOrEmpty(medicationEntity.Time))
    				temperature.Add(new XElement("vHour", (DateTime.Parse(medicationEntity.Time).Hour).ToString()));
    			.........
    			.........
    			xmlDoc.Root.Add(temperature);
    		}
    		newTempratureList.Add(medicationEntity);
    	}
    }
