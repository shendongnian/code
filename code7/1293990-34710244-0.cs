        while (rd.Read()) {
            MeterInformation mi = new MeterInformation();
            mi.MeterId = rd.GetInt32(0);
            mi.MeterType = rd.GetString(1);
            mi.MeterName = rd.GetString(2);
            mi.MeterDescription = rd.GetString(3);
            mi.MeterSerial = rd.GetString(4);
            mi.MeterMPAN = rd.GetString(5);
            mi.MeterCreatedOn = rd.GetDateTime(6);
            mi.MeterLocation = rd.GetString(7);
            mi.MeterBuilding = rd.GetString(8);
            mi.MeterSite = rd.GetString(9);
            MeterInfo.Add(mi);
        }
