    public Sub GetPDFfromAPI(int id)
           dim myfile as byte() = Nothing
            dim handler as HttpClientHandler  = new HttpClientHandler()
            dim myclient as new HttpClient(handler)
            dim client as new 
                client.BaseAddress = new Uri("http://myhosturl")
                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"))
             
                Dim response as HttpResponseMessage  = client.Get("api/ControllerName/"+id.ToString())
                if (response.IsSuccessStatusCode) then
                
                     myfile = response.Content.ReadAsByteArray()
                    
                
                else
                
                    return null
                End if
        Dim oFileStream As System.IO.FileStream
        oFileStream = New System.IO.FileStream("myfile.pdf",System.IO.FileMode.Create)
        oFileStream.Write(myfile, 0, myfle.Length)
        oFileStream.Close()
