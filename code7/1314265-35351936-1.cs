    var listOfPropertiesToSortBy = new List<string>();
    var versusHistories = from th in db.TeamHistories
                          where th.TeamOneName.ToLower() == team.ToLower();
    foreach (var property in listOfPropertiesToSortBy ) {
           versusHistories = versusHistories.GroupBy(vh => typeof(TeamHistories).GetProperty(property).GetValue(vh));
    }
