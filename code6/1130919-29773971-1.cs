    var myTable = (from u in UserIds
                   join p1 in UserProfiles on u.UserId1 equals p1.UserId
                   join p2 in UserProfiles on u.UserId2 equals p2.UserId
                   // etc...
                   select new
                   {
                       User1FullName = p1.FirstName + " " + p1.LastName,
                       User2FullName = p2.FirstName + " " + p2.LastName,
                       // etc...
                   });
