        public ActionResult DownloadActionAsPDF()
                {
                  return new Rotativa.ActionAsPdf("Create_Brochure") { FileName = "TestPdf.pdf"};
                }
   
        public ActionResult Create_Brochure()
                {
                   //Your logic....
                   return View()  
                }
