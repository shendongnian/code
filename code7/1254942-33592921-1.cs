        public ActionResult Create_Brochure_PDF()
        {
    
            IEnumerable<ProductsPropertiesVM> newmodel = Session["TemplateData"] as IEnumerable<ProductsPropertiesVM>;
        
            IEnumerable<BrochureTemplateProperties> samplePDF = newmodel.Where(.... 
         
            rerurn View();
      }
