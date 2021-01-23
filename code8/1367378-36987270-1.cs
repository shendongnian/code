    public class MyController {
      public ActionResult GetCustIdBarCode(Guid code) {
        var img = CreateBarcode(code);
        // I'm not sure if the using here will work or not. It might work
        // to just remove the using block if you have issues.
        using (var strm = new MemoryStream()) {
          img.Save(strm, "image/png");
          return File(strm, "image/png");
        }
      }
     
      public ActionResult GetSalesBarcode(Guid salesId) {
        // Similar to above method
      }
    }
