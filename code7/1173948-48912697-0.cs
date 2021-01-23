    var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(“FullSharePointURIofDocument“);
    request.Timeout = System.Threading.Timeout.Infinite;
    request.Credentials = new 
    System.Net.NetworkCredential(“SharePointUser“,”SharePointUserPassword“);
    request.Method = “DELETE“;
    var response = (System.Net.HttpWebResponse)request.GetResponse();
