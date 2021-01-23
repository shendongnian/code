    [System.Web.Http.AcceptVerbs("GET", "POST")]
    [System.Web.Mvc.HttpGet]
    public async Task<string> ServiceModelsForTournamentBase(int id)
        {
            var jsons = await Task.WhenAll(
                  GetJsonFromApi("api/asyncdata/searchmatchfortournament/" + id, _siteUrl),
                  GetJsonFromApi("api/asyncdata/scoringplayersfortournament/" + id, _siteUrl),
                  GetJsonFromApi("api/asyncdata/tournamentteams/" + id, _siteUrl)
            );
            var matchInfoJson = jsons[0];
            var scoringPlayersJson = jsons[1];
            var teamsJson = jsons[2];
    
        // return json containing all three
        }
