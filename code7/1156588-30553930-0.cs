    Lat = Convert.ToDouble(splitline[3]);
    if (splitline[4] == "S")
        Lat = 0.0 - Lat;
    Long = Convert.ToDouble(splitline[5]);
    if (splitline[6] == "W")
        Long = 0.0 - Long;
