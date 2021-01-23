    public JsonResult GetWithHttpClient()
    {
    
    Employee employee = null;
    using (var client = new HttpClient())
    {
               
        client.BaseAddress = new Uri(path);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = client.GetAsync("api/Employees/12345").Result;
                
        //the IsSuccessStatusCode property is false if the status is an error code. 
        //All the error: {StatusCode: 401, ReasonPhrase: 'Unauthorized', Version: 1.1, Content: System.Net.Http.StreamContent, Headers:{  Pragma: no-cache  X-SourceFiles: =?UTF-8?B?QzpcRkFCSU9fQ09ESUNFXE15RXhhbXBsZVxXZWJBcHBsaWNhdGlvbjFcV2ViQXBwbGljYXRpb24xXGFwaVxFbXBsb3llZXNcMTIzNDU=?=  Cache-Control: no-cache  Date: Tue, 28 Jul 2015 14:47:03 GMT  Server: Microsoft-IIS/8.0  WWW-Authenticate: Bearer  X-AspNet-Version: 4.0.30319  X-Powered-By: ASP.NET  Content-Length: 61  Content-Type: application/json; charset=utf-8  Expires: -1}}
            if (response.IsSuccessStatusCode)
            {
                employee = response.Content.ReadAsAsync<Employee>().Result;               
        }
    }
    return Json (employee, JsonRequestBehavior.AllowGet); 
