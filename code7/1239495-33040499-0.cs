    class Program
        {
            static void Main(string[] args)
            {
    
                var URL = "google.com/Somepath/";
                var CorrectedURL = new TopLevelURL(URL,"http").ParsedURL;
                Console.WriteLine(CorrectedURL);
                Console.Read();
            }
    
    
        }
    
        public class TopLevelURL
        {
        
            private string URL = "";
            private string Protocol = "";
            public string ParsedURL { get; private set; }
    
            public TopLevelURL(string _URL,string WantedProtocol)
            {
                URL = _URL;
                Protocol = (WantedProtocol == "http" ? "http://" : "https://") ?? "http://";
                ParseURL();
            }
    
            private void ParseURL()
            {
                if (URL.ToLower().Contains("http"))
                {
                    //If the URL is provided with the protocol check the validity of URL
                    if (!Uri.IsWellFormedUriString(URL, UriKind.RelativeOrAbsolute))
                        throw new Exception("Malformed URL!");
    
                    //If the URL is provided with the protocol and is valid, just get the absolute URL. e.g: http://helloworld.com
                    URL = new Uri(URL).AbsoluteUri.Replace(new Uri(URL).AbsolutePath, "");
                }
                else
                { 
                    //If the URL does not have the protocol then start constructing it with the protocol
                    URL = Protocol + URL;
                    if(!Uri.IsWellFormedUriString(URL,UriKind.RelativeOrAbsolute))
                        throw new Exception("Could not parse the URL. Invalid character before the domain name!");
    
                    URL = new Uri(URL).AbsoluteUri.Replace(new Uri(URL).AbsolutePath,"");
    
                }
                ParsedURL = URL;
            }
    
    
        
        }
