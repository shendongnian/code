    var qe = new QueryExpression
    {
        EntityName = "appointment",
        ColumnSet = new ColumnSet("subject"),
        LinkEntities =
        {
            new LinkEntity
            {
                EntityAlias = "ap",
                JoinOperator = JoinOperator.Inner,
                Columns = new ColumnSet(false),
                LinkFromEntityName = "appointment",
                LinkFromAttributeName = "activityid",
                LinkToEntityName = "activityparty",
                LinkToAttributeName = "activityid",
                LinkCriteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("partyid", ConditionOperator.Equal, userid),
                    },
                },
            },
        },
    };
