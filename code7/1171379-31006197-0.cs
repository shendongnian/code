    int i = 0, j = 0;
    foreach (var item in Model.Arrangements)
    {
        foreach(var player in item.InterestedPlayers)
        {
            Html.CheckBoxFor(m => m.Arrangements[i].InterestedPlayers[j].IsSelect) 
            Html.LabelFor(m => m.Arrangements[i].InterestedPlayers[j].Name)
            j++;
        }
        j = 0;
        i++;
    }    
