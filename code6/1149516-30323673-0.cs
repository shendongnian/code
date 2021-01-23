    var toRemove = null;
    foreach (string item in hillracing.searchRaces(RaceID).RaceList) // Loop through List with foreach.
    {
        if (item == SelectedItem)
        {
            toRemove = item;
            break; //Can break here if you're sure there's only one SelectedItem
        }
    }
    hillracing.searchRaces(RaceID).Racelist.Remove(toRemove);
