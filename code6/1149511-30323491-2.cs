    List<string> = hillracing.searchRaces(RaceID).RaceList;
    for(int i = 0; i < list.Count; i++)
    {
        if(list[i] == SelectedItem)
             list[i] = null;
    }
