    var versusHistories =
                from th in db.TeamHistories
                where th.TeamOneName.ToLower() == team.ToLower()
    if (condition)
    {
        versusHistories = versusHistories.GroupBy(g => ..something..);
    }
    else if (anotherCondition)
    {
        versusHistories = versusHistories.GroupBy(g => ..something else..);
    }
