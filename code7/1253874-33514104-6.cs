    public ActionResult MyAction(MyModel model)
    {
        foreach(var f in model.FriendList)
        {
          db.Friends.Add(f);
          db.SaveChanges();
        }
    }
