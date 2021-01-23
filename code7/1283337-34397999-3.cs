    using System.Threading;
    using System.Threading.Tasks;
    
    Parallel.For(0, lst.Count, index =>
    {
              string URL = lst[index].InnerText;
              var request = (HttpWebRequest)WebRequest.Create(URL);
              HttpWebResponse response = (HttpWebResponse)request.GetResponse();
              string responseURI = response.ResponseUri.ToString();
        
    });
