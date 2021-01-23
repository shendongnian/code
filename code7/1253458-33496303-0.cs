    public class PDFDownloadController : Controller 
    {
         public ActionResult Download() {  
             using (var myWebClient = new WebClient()) 
             {
                var product = .... // Init product
                byte[] binaryData = myWebClient.DownloadData(product.Url);
                return File(binaryData, "application/pdf");
             }
         }
    }
