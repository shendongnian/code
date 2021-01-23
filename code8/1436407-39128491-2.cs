    int count = dictionary.Count(D => D.Key.StartsWith("location-"));
        for (int i = 1; i <= count; i++)
        {
            if (dictionary.ContainsKey("location-"+i))
            {
                string locationData = dictionary["location-"+i];
                string[] locationDataRow = locationData.Split(':');
                Debug.WriteLine("Location Desc from dictionary is : " + locationDataRow[0]);
                Debug.WriteLine("Location Add from dictionary is : " + locationDataRow[1]);
            }
        }
