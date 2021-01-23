    using(reader = sqlSelectCommand.ExecuteReader())
    {
        while (reader.Read())
        {
            foreach (SPpowerPlant powerPlant in powerPlantList)
            {
                powerPlant.ID = reader.GetInt32(0);
                powerPlant.projectName = reader.GetString(1).ToString();
                powerPlant.location = reader.GetString(2); 
                powerPlant.shortName = reader.GetString(3); 
                powerPlant.numberOfWtgs = reader.GetInt32(4); 
                powerPlant.mwWtg = reader.GetDouble(5); 
                powerPlant.mwTotal = reader.GetDouble(6); 
                powerPlant.projectShareWeb = reader.GetDouble(7); 
                powerPlant.mwWeb = reader.GetDouble(8); 
                powerPlant.phase = reader.GetString(9); 
                powerPlant.phaseNumber = reader.GetString(10);
                powerPlant.phaseDescription = reader.GetString(11); 
                powerPlant.projectProgress = reader.GetDouble(12); 
                powerPlant.mwDeveloped = reader.GetDouble(13); 
                powerPlant.projectManager = reader.GetString(14); 
                powerPlant.spaceUrl = reader.GetString(15); 
                powerPlant.country = reader.GetString(16); 
                powerPlant.technology = reader.GetString(17);
                powerPlant.state = reader.GetString(18);
                powerPlant.allPermits = reader.GetDateTime(19);
                powerPlant.cod = reader.GetDateTime(20);
                powerPlant.stateSince = reader.GetDateTime(21);
                powerPlant.spID = reader.GetInt32(22);
                powerPlant.currency = reader.GetString(23);
                powerPlant.possibleWtgTypes = reader.GetString(24);
                powerPlant.hubHeight = reader.GetString(25);
                powerPlant.visibility = reader.GetString(26);
                powerPlant.templateName = reader.GetString(27);
                powerPlantList.Add(powerPlant);
            }
        }
    }
    sqlConnection.Close(); 
    return powerPlantList;
