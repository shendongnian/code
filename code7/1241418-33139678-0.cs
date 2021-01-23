              DBConnection.database.GetCollection<Log>("Logs").Update(
                                         Query<Log>.EQ(l => l.Id, UmbrellaLogIdAsObjectId),
                                         Update<Log>.Push(l => l.logEventsIdList, aLogEvent.Id),
                                                             new MongoUpdateOptions
                                                             {
                                                                 WriteConcern = WriteConcern.Acknowledged
                                                             });  
