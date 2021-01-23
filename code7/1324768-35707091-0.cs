    for (int i = 0; i < testCount; i++)
    {
          Debug.Assert(client.Headers.Count == 1); // Content-type is set   
          var response = client.UploadString("http://localhost:8080/BlocksOptimizationServices/dataPositions", "POST", jsonInput);    
          Debug.Assert(client.Headers.Count == 0); // Zero!
    }
