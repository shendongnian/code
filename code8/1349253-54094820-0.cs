    // Microsoft.AspNetCore.Http.Extensions.HttpRequestMultipartExtensions
    var boundary = Request.GetMultipartBoundary();
   
    if (!string.IsNullOrWhiteSpace(boundary))
      return BadRequest();
