    Console.WriteLine("Started"); 
    HttpClient client = new HttpClient();
    client.MaxResponseContentBufferSize = 9999999;
    var uri = new Uri("http://TestSite.azurewebsites.net/Service.svc/webHttp/displayPDF?pdfName=testFile.pdf");
    var responseTask = client.GetStreamAsync(uri);
    var response = responseTask.Result;
    using (System.IO.FileStream output = new System.IO.FileStream(@"C:\Users\Admin 1\Documents\MyOutput.pdf", FileMode.Create))
    {
        response.CopyTo(output);
    }
