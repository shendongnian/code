    select new
    {
       AspNetUsersId = AspNetUsers.AspNetUsersId,
       UsertId = UserDetails.UserID
    }).ToList()
    .Select (m => new {
       m => m.AspNetUsersId,
       UsertId = (int?)m.UsertId
    });
