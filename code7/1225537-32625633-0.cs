    public  ActionResult ActionMethordNam()
    {
       List<Systems>  systems;
       var query = db.SystemFamily.Select(c=>c.SystemFamilyID).Tolist(); 
       foreach(var sid in query)
       { 
          systems = db.Systems.Select(c=>c.SystemFamilyID == sid).Tolist(); 
       }
       int count=systems.Count();//Here you will  get count
       return View();
    }
