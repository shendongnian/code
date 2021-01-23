     HttpContent httpContent = new FormUrlEncodedContent(postData);           
     // whoops! .Result makes this line synchronous.
     HttpResponseMessage response =  client.PostAsync("/mydata", httpContent).Result;
     var responsecode = (int)response.StatusCode; 
     if (response.IsSuccessStatusCode)
     {
         var responseBodyAsText = await response.Content.ReadAsStringAsync();
         return responseBodyAsText;
     }
     else
     {
         return responsecode +" " +response.ReasonPhrase; 
     }
