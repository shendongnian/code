    class HomeContoller
    {
         ServiceClass1  _serviceClass1
         public HomeContoller(ServiceClass1  serviceClass1)
         {
             _serviceClass1 = serviceClass1;
         }
    
         public ActionResult Index()
         { 
             var data = _serviceClass1.GetFancyData();
             return View(data);
         }
    
    
    }
