    double epsilon = 0.000005;
    List<int> possLatCityIds = new List<int>();  // stores your matching IDs for later
    double dblLat = 39.59833333;  // hard-coded value here, but could come from anywhere
    // Possible Latitudes
    foreach (KeyValuePair<int, double> kvp in cityLatPoints)
    {
        if (nearlyEqual(kvp.Value, dblLat, epsilon))
        {
            //Values are the same or similar
            possLatCityIds.Add(kvp.Key);  // ID gets added to the list
        }
    }
