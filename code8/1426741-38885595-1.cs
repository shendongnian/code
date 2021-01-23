    public ActionResult MyList()
    {
      List<CarsModel> myList = new List<CarsModel>();
      myList.Add( new CarsModel() { Brand = "Ford", Model = "F50", Speed = 150} );
      myList.Add( new CarsModel() { Brand = "Lamborgini", Model = "Countach", Speed = 290} );
      myList.Add( new CarsModel() { Brand = "Mattel", Model = "RedShadow", Speed = 5} );
      return View(myList);
    }
