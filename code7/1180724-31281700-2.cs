    foreach (Room r in RoomsList) {
        if (RoomDictionary.Contains(r.UserID))
            RoomDictionary[r.UserID].Add(r.Name);
        else
            RoomDicationary.Add(r.UserID, new List<string>() { r.Name });
    }
