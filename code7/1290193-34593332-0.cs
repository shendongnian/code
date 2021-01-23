    var request = (HttpWebRequest)WebRequest.Create("http://192.168.0.108/api/homematic.cgi");
    var rpc_request = "{ \"method\": \"Session.login\", \"params\": [ \"username\": \"root\", \"password\": \"root\" ], \"id\": null}";
    request.ContentType = "application/json";
    request.Method = "POST";
    using (var stream = request.GetRequestStream())
    using (var writer = new StreamWriter(stream))
    {
        stream.Write(rpc_request);
    }
    using (var response = (HttpWebResponse)request.GetResponse())
    using (var stream = response.GetResponseStream())
    using (var reader = new StreamReader(stream))
    {
        Console.WriteLine("Status Code = {0}", response.StatusCode);
        Console.WriteLine(reader.ReadToEnd());
    }
    Console.ReadLine();
