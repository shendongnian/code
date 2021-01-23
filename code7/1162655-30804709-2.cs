    if (!(rating.RatedFromList.Where(x=> x.UserName == User.Identity.Name).Count() > 0))
    {
        rating.Likes++;
        rating.RatedFrom.Add(new RatedFrom {  UserName = User.Identity.Name }); 
    }
