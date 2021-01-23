    ActivityLog activity = null;
    // subquery to be later used for EXISTS
    var maxSubquery = QueryOver.Of<ActivityLog>()
        .SelectList(l => l
            .SelectGroup(item => item.UserID)
            .SelectMax(item => item.Time)
        )
        // WHERE Clause
        .Where(x => x.UserID == activity.UserID )
        // HAVING Clause
        .Where(Restrictions.EqProperty(
            Projections.Max<ActivityLog>(item => item.Time),
            Projections.Property(() => activity.Time)
        ));
    // final query without any transformations/projections... but filtered
    var result = session.QueryOver<ActivityLog>(() => activity)
        .WithSubquery
        .WhereExists(maxSubquery)
        .List<ActivityLog>()
        ;
