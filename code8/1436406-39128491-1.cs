    int count = dictionary.Count(D => D.Key.StartsWith("location-"));
    ArrayList locationDesc = new ArrayList();
    ArrayList locationAddress = new ArrayList();
        for (int i = 1; i <= count; i++)
        {
            if (dictionary.ContainsKey("location-"+i))
            {
                string locationData = dictionary["location-"+i];
                string[] locationDataRow = locationData.Split(':');
                locationDesc.Add(locationDataRow[0]);
                locationAddress.Add(locationDataRow[1]);
            }
        }
       
    for (int i = 0; i < locationDesc.Count; i++)
	{
	    Debug.WriteLine("Location Desc from dictionary is : " + locationDesc[i]);
        Debug.WriteLine("Location Add from dictionary is : " + locationAddress[i]);
	}
