    var qe2 = new QueryExpression
    {
        EntityName = "systemuser",
        ColumnSet = new ColumnSet(false),
        LinkEntities =
        {
            new LinkEntity
            {
                EntityAlias = "ap",
                Columns = new ColumnSet(false),
                JoinOperator = JoinOperator.Inner,
                LinkFromEntityName = "systemuser",
                LinkFromAttributeName = "systemuserid",
                LinkToEntityName = "activityparty",
                LinkToAttributeName = "partyid",
                LinkEntities =
                {
                    new LinkEntity
                    {
                        EntityAlias = "a",
                        Columns = new ColumnSet("subject"),
                        JoinOperator = JoinOperator.Inner,
                        LinkFromEntityName = "activityparty",
                        LinkFromAttributeName = "activityid",
                        LinkToEntityName = "appointment",
                        LinkToAttributeName = "activityid",
                    },
                },
            },
        },
        Criteria = new FilterExpression
        {
            Conditions =
            {
                new ConditionExpression("systemuserid", ConditionOperator.Equal, userid),
            },
        },
    };
