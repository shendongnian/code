    var users =  myDataTable.AsEnumerable()
                    .Select(r=> new {
                        UserId = r.Field<int>("UserId"),
                        CreatedTime = r.Field<DateTime>("createdTime")
                    }).ToList();
                var groupedUsersResult = from user in users where user.CreatedTime > user.CreatedTime.AddDays(-7) group user by 
                                       new {user.CreatedTime.Year,user.CreatedTime.Month,user.CreatedTime.Day,Minute=(user.CreatedTime.Minute/5),user.UserId}
                                       into groupedUsers select groupedUsers;
