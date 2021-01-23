       public ActionResult Index()
            {
                return View(GetChart().FileContents);
            }
      public FileContentResult GetChart()
        {
         Chart myChart = new Chart();
        ///when you setup your chart you can 
        myChart.ToWebImage(format: "png");
        return new FileContentResult(myChart.GetBytes(), myChart.ImageFormat);
        
        }
