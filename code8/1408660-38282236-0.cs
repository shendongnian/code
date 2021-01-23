    List<City> listWithCities = new List<City>(); //create a list of cities
	using(StreamReader file = new StreamReader(fullName))//open a reader
	{
		string line = String.Empty;
		while((line = file.ReadLine()) != null)	//loop lines
		{
			if(!line.Contains(',') || line == String.Empty || line.IndexOf("//") == 0)	//to avoid comments, or empty lines, or lines without separator
				continue;
					
			if(line.Contains("//"))
				line = line.Substring(0, line.Length - line.Substring(line.IndexOf("//")).Length); //skipping comments of type '//' if you need
					
			string[] parts = line.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
					
			if(parts.Length < 4) //there are less than 4 parts, so it's not a valid data line? You may skip that if you want
				continue;
					
			int indexOfPossiblyExistingItem = Array.FindIndex(listWithCities.ToArray(), cit => cit.name == parts[0]);
			if(indexOfPossiblyExistingItem != -1) //the city exists
			{
				listWithCities[indexOfPossiblyExistingItem].districts.Add(new District {district = parts[2], zipCode = parts[3]}); //adding a new destrict ot the list
			}
			else //city does not exist
			{
				listWithCities.Add(new City{name = parts[0], cityCode = Convert.ToInt32(parts[1]), disricts = new List<District>(new District[] {new District{district = parts[2], zipCode = parts[3]})}}) //adding new city + 1 disctrict in the list
			}
		}
		file.Close();
	}
