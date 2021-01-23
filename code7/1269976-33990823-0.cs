     public async Task<FileStreamResult> DownloadInvoice()
            {
                string invoiceId = new Guid(); //Test data
                var url = "http://localhost:7000/api/v1/downloadfile/<invoiceid goes here>";
    
                string path = @"C:\Temp\" + invoiceId + ".pdf";
                
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(url).Result;
    
                    var stream = await response.Content.ReadAsAsync<Byte[]>();
    
                    System.IO.File.WriteAllBytes(path, stream);
    
                    var fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
    
                    return new FileStreamResult(fileStream, "application/pdf");
                }
            }
