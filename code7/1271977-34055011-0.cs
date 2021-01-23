    int spacesPerLevel = spaces.Count / numLevels; // 30 / 3 = 10
    for (int i = 0; i < numLevels/*3*/; i++)
    {
       int listRangeStart = (i * spacesPerLevel/*10*/); // for i = 2: 20
        ParkingSpaces subSpaces = spaces.GetRange(listRangeStart, spacesPerLevel); 
                                     // .GetRange(20, 10) 
