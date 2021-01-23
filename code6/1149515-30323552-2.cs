    // Use of Single() here assumes the object definitely exists. 
    // Use SingleOrDefaul() if there is a chance it might not exist.
    var item = hillracing.searchRaces(RaceID)
                         .RaceList
                         .Where(x => x.Item == SelectedItem).Single();  
    hillracing.searchRaces(RaceID).RaceList.Remove(item);
