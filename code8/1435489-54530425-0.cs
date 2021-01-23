        WebTestRequest request2 = new WebTestRequest("webservice");
        request2.Headers.Add("Content-Type", "application/json");
        request2.Method = "POST";
        request2.Encoding = System.Text.Encoding.GetEncoding("utf-8");
        StringHttpBody request2Body = new StringHttpBody();
        request2Body.ContentType = "application/json";
        request2Body.InsertByteOrderMark = false;
        request2Body.BodyString = @"{<body>}";
        request2.Body = request2Body;
        WebTestResponse res = new WebTestResponse();
        console.WriteLine(res.BodyBytes);
       yield return request2;
       /*This will generate a new string which can be part of your filename when      you run performance tests*/
       String randomNo = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "").Replace(" ", "").Replace(":", "");
       /*This will generate a new file each time your WebRequest runs so you know what the server is returning when you perform webtests*/
       /*You can use some Json parser if your response is Json and capture and validate the response*/
       System.IO.File.WriteAllText(@"C:\Users\XXXX\PerformanceTestRequests\LastResponse" + randomNo+ ".txt", this.LastResponse.BodyString);
       request2 = null;
    }
