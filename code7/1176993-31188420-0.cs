     public void MockHttpRequesteRsponse() 
         { 
             byte[] responseData = Encoding.UTF8.GetBytes("200 OK"); 
             Stream stream = new MemoryStream(responseData); 
             WebRequest request = (WebRequest)mocks.StrictMock(typeof(WebRequest)); 
             WebResponse response = (WebResponse)mocks.StrictMock(typeof(WebResponse)); 
             Expect.On(request).Call(request.GetResponse()).Return(response); 
             Expect.On(response).Call(response.GetResponseStream()).Return(stream); 
 
 
             mocks.ReplayAll(); 
 
 
             Stream returnedStream = GetResponseStream(request); 
 
 
             Assert.Same(stream, returnedStream); 
             string returnedString = new StreamReader(returnedStream).ReadToEnd(); 
             Assert.Equal("200 OK", returnedString); 
         } 
//
    private Stream GetResponseStream(WebRequest request) 
         { 
             return request.GetResponse().GetResponseStream(); 
        } 
