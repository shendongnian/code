    using System.Net;
    using System.Net.Http; 
    
    WebRequest req = HttpWebRequest.Create("http://yourwebsite.com");
    req.Method = "GET";
    
    string source;
    using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream()))
    {
        source = reader.ReadToEnd();
    }
    
    System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt");
    file.WriteLine(source);
    
    file.Close();
