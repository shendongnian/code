    var userQuery = 
            from user in db.Users
            where (user.FirstName.StartsWith(searchValue)
                   || user.LastName.StartsWith(searchValue)
                   || user.Name.StartsWith(searchValue)
                   || user.School.StartsWith(searchValue)
                   || user.SchoolClass.StartsWith(searchValue))
                   && user.UserId != userId
            select new {
                User = user,
                // I'm using single because I'm guessing there's only one match
                Status = db.Friendship
                    .Where(f => f.FriendUserId == user.UserId && f.UserId == userId)
                    .SingleOrDefault(),
            };
