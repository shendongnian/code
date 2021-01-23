    public ActionResult View()
    {
      var name= new List<string>();
      using(var db=new YourDbContext())
      {
         name=db.Users.Select(s=>s.Name);
      }
      //to do : return something
    }
