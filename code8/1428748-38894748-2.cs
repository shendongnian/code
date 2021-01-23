    @foreach (var team in Model.GetTeams)
    {
        var i = 0;
        foreach (var employee in team.Medewerkers)
        {
            if (i == 0 || i % 2 == 0)
            {
                @:<li class="flip-card">
                    @:<div class="flip-card-back">
                    @:</div>
            } 
            else
            {
                    @:<div class="flip-card-front">
                    @:</div>
            }
            if (i % 2 == 1 || i == team.Medewerkers.Count - 1)
            {
                </li>
            }
            i++;  
        }
    }
