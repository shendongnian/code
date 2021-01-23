    using (var context = new Friendsdb())
    {
      context.UserDetails.First(userDetail => userDetail.Id == HttpContext.User.Id).IsLoggedin = true;
      context.SaveChanges();
    }
