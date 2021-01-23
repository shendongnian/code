    public ActionResult Index(int someparameter)
    {
        MyFirstEntity firstEntity=
            BusinessLogic.GetMyFirstEntity(someparameter);
        MySecondEntity secondEntity=
            BusinessLogic.GetMySecondEntity(someparameter);
 
        MyViewModel myViewModel = new MyViewModel 
        {           
            FirstEntity = firstEntity,
            SecondEntity= secondEntity
        };
 
        return View(myViewModel);
    }
