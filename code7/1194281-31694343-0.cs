    private MemoryStream GetStreamA() {
      return GetSamplePdf("A");
    }
    public ActionResult PdfA() {
      return Json(GetStreamA().GetBuffer(), JsonRequestBehavior.AllowGet);
    }
    // ...
    // Same for PdfB()/GetStreamB()
    // ...
    public ActionResult PdfSpider() {
      var streamA = GetStreamA();
      var streamB = GetStreamB();
      // ... 
    }
