    public ActionResult Clubs(int comp)
    {
      using(var context=new DataDBEntities())
      {
         var query= context.Clubs;
         if(comp!=0)//default value
         { 
            query=query.Where(c=>c.League_Table ==comp);
         }
         return View(query.ToList());
      }
    }
