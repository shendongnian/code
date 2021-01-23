    var response = ( from e in db.tblEventTypes              
                      from f in db.tblEvents.where(x=>x.FightTypeId ==e.eventTypeId).DefaultIfEmpty()
                      from w in db.tblUserWebApp.where(x=>x.Id==f.ModifiedUserId)
                      orderby f.LastUserModified descending
                      select new {
                                FightTypeName  = e.eventTypeName,
                                EventID =  f.EventID,
                                FightTypeId=f.FightTypeId,
                                Title = f.Title,
                                Date = f.Date,
                                Location = f.Location, 
                                UserSelectFavoriteFlag =f.UserSelectFavoriteFlag ,
                                Price=f.Price,
                                UserPredictionFlag=f.UserPredictionFlag,
                                PredictionStartDate=   f.PredictionStartDate ,
                                PredictionEndDate   = f.PredictionEndDate,
                                ModifiedUserId = w.Id,
                                ModifiedUser = w.LoginName,
                                LastUserModified = f.LastUserModified,
            });
