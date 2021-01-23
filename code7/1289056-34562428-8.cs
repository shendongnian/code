    public ActionResult BikeEdit(int id)
    {
      var bikeEditVm=new BikeEditVm { Id=id};
      var bikeEntity = db.Bikes.FirstOrDefault(s=>s.Id==id);
      if(bikeEntity!=null)
      {
        bikeEditVm.ModelName=bikeEntity.ModelName;
        bikeEditVm.Color=bikeEntity.Color;   
        return View(bikeEditVm); 
      }
      return View("NotFound"); // return a bike not found view to user
    }
