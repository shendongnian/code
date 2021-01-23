    QueryExpression qe = new QueryExpression
                  {
                      EntityName = "appointment",
                      ColumnSet = new ColumnSet("activityid", "subject", "scheduledstart", "scheduledend", "location", "description"),
                      Criteria = new FilterExpression
                      {
                          FilterOperator = LogicalOperator.And,
                          Conditions = 
                            {
                                new ConditionExpression("scheduledend", ConditionOperator.GreaterThan, startTime),
                                new ConditionExpression("scheduledstart", ConditionOperator.LessThan, endTime)
                            }
                      },
                      LinkEntities = 
                      {
                          new LinkEntity
                          {
                                LinkFromEntityName = "activitypointer",
                                LinkFromAttributeName = "activityid",
                                LinkToEntityName = "activityparty",
                                LinkToAttributeName = "activityid",
                                LinkCriteria = new FilterExpression
                                {
                                    FilterOperator = LogicalOperator.And,
                                    Conditions = 
                                    {
                                        new ConditionExpression("participationtypemask", ConditionOperator.In, new int[] { 5, 6, 7, 9 }),
                                        new ConditionExpression("partyid", ConditionOperator.Equal, userResponse.UserId)
                                    }
                                }
                           },
                           new LinkEntity
                           {
                                EntityAlias = "requiredattendees",
                                Columns = new ColumnSet(false),
                                JoinOperator = JoinOperator.Inner,
                                LinkFromEntityName = "activitypointer",
                                LinkFromAttributeName = "activityid",
                                LinkToEntityName = "activityparty",
                                LinkToAttributeName = "activityid",
                                LinkCriteria = new FilterExpression
                                {
                                    Conditions = 
                                    {
                                        new ConditionExpression("participationtypemask", ConditionOperator.Equal, 5)
                                    }
                                },
                                LinkEntities =
                                {
                                    new LinkEntity
                                    {
                                        EntityAlias = "contact",
                                        Columns = new ColumnSet("fullname"),
                                        JoinOperator = JoinOperator.Inner,
                                        LinkFromEntityName = "activityparty",
                                        LinkFromAttributeName = "activityid",
                                        LinkToEntityName = "contact",
                                        LinkToAttributeName = "contactid"
                                    },
                                }
                           }
                       }
                  };
                  qe.Distinct = true;
                  slos.RetrieveMultiple(qe);
