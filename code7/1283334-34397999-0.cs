    using System.Threading;
    using System.Threading.Tasks;
    
    Parallel.ForEach(lst, (node) =>
    {
              string URL = node.InnerText;
              var request = (HttpWebRequest)WebRequest.Create(URL);
              HttpWebResponse response = (HttpWebResponse)request.GetResponse();
              string responseURI = response.ResponseUri.ToString();
        
    });
