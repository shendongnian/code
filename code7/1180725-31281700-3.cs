    foreach (Room r in RoomsList) {
        foreach (int id in r.UserID) {
            if (RoomDictionary.Contains(id))
                RoomDictionary[id].Add(r.Name);
            else
                RoomDicationary.Add(id, new List<string>() { r.Name });
        }
    }
