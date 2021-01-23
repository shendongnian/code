    using Microsoft.VisualStudio.Services.WebApi;
    
    
    HttpResponseMessage response = client.PatchAsync(url, content).Result;
    response.EnsureSuccessStatusCode();
