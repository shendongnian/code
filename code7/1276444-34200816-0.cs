    // Generate a SAS key with the Signature Generator.: 
    var sas = "SharedAccessSignature sr=https%3a%2f%2freddogeventhub.servicebus.windows.net%2ftemperature%2fpublishers%2flivingroom%2fmessages&sig=I7n%2bqlIExBRs23V4mcYYfYVYhc6adOlMAeTY9VM9kNg%3d&se=1405562228&skn=SenderDevice";
    
    // Namespace info.
    var serviceNamespace = "myeventhub";  
    var hubName = "temperature";  
    var deviceName = "livingroom";
    
    // Create client.
    var httpClient = new HttpClient();  
    httpClient.BaseAddress =  
               new Uri(String.Format("https://{0}.servicebus.windows.net/", serviceNamespace));
    httpClient.DefaultRequestHeaders  
               .TryAddWithoutValidation("Authorization", sas);
    
    Console.WriteLine("Starting device: {0}", deviceName);
    
    // Keep sending.
    while (true)  
    {
        var eventData = new
        {
            Temperature = new Random().Next(20, 50)
        };
    
        var postResult = httpClient.PostAsJsonAsync(
               String.Format("{0}/publishers/{1}/messages", hubName, deviceName), eventData).Result;
    
        Console.WriteLine("Sent temperature using HttpClient: {0}", 
               eventData.Temperature);
        Console.WriteLine(" > Response: {0}", 
               postResult.StatusCode);
        Console.WriteLine(" > Response Content: {0}", 
               postResult.Content.ReadAsStringAsync().Result);
    
        Thread.Sleep(new Random().Next(1000, 5000));
    }
