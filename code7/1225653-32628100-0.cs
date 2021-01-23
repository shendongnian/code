    var newList = o_userLoginList.GroupBy(gby => new {gby.UserID, gby.ID2})
                    .Select(x => new UserLoginRecord
                    {
                        UserID = x.Key.UserID,
                        ID2 = x.Key.ID2,
                        LoginTimeStamp = x.Min(y=>y.LoginTimeStamp),
                    });
