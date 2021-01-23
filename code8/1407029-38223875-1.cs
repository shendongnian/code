    public ActionResult Details(int id)
    {
      var client = new Client();
      //Hardcoding the values for demo. You may get it from db using the Id
      client.Name="Microsoft";
      client.Jobs= new List<Job>{
        new Job { Title ="Developer"},
        new Job { Title ="proDuct Manager"}
      };
      return View(client);
    }
