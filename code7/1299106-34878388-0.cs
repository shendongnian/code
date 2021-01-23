    // Send request to get headers
     response = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
    
    // Check status code
    if (!response.IsSuccessStatusCode) {
      // Error...
    );
    }
                   
    // Get Content Headers
    HttpContentHeaderCollection contentHeaders = response.Content.Headers;
    
    
    // Make decision and dispose client if you wish
    if (...) {
       client.Dispose();
    }
