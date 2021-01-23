    var url="http://localhost:8000/DEMOService/Client/156";
    var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
    using (var response = webrequest.GetResponse()) 
    {
        using (var reader = new StreamReader(response.GetResponseStream()))
        {
            var result = reader.ReadToEnd();
            Label1.Text = Convert.ToString(result);
        }
    }
