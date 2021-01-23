    public ActionResult GETDATE(string id)
    {
       using (var db = new TestContext())
       {
          var createDate = db.Students.SingleOrDefault(x => x.Id == id).CreateDate;
          //do something...
          return View();
       }
    }
