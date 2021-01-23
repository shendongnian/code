    @model YourNameSpaceHere.Person
    @using (Html.BeginForm())
    {
        var qCounter = 0;
    
        foreach (var favoriteGroup in Model.Favorites)
        {    
            <h4>@favoriteGroup.GroupName</h4>
            @Html.HiddenFor(f => f.Name)
            foreach (var option in favoriteGroup.Options)
            {
                @Html.Hidden("Favorites[" + qCounter + "].GroupName", favoriteGroup.GroupName)
    
                @Html.RadioButton("Favorites[" + qCounter + "].SelectedAnswer", option.Key)
                <span>@option.Value</span>
    
            }
            qCounter++;
        }    
        <input type="submit" />
    }
