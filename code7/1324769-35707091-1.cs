    using (var client = new WebClient())
    {            
        for (int i = 0; i < testCount; i++)
        {
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
        
            var response = client.UploadString("http://localhost:8080/BlocksOptimizationServices/dataPositions", "POST", jsonInput);
        }
