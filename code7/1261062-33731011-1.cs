        public ActionResult Index()
                {
                    heatingAreas = db.HeatingAreas.ToList();
                    heatingImages = db.HeatImages.ToList();
        
                    List<HeatingAreaViewModel> myModel = heatingAreas.Zip(heatingImages, (a, b) => new HeatingAreaViewModel {HeatingArea = a, HeatImage = b})
                    
                    return View(mymodel);
                }
