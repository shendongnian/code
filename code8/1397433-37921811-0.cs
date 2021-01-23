    public XmlTextReader readXML(string postcode, string response, string accessCode)
    {            
       string strURL = string.Empty;
       string url = "http://pcls1.craftyclicks.co.uk/xml/rapidaddress?postcode=" + postcode + "&response=" + response + "&key=" + accessCode;
       using(WebRequest wrURL = WebRequest.Create(url))
       {
          //string xml = new WebClient().DownloadString(url); //What is this for ? I dont see you using this in your code ?!
          using(Stream objStream = wrURL.GetResponse().GetResponseStream())
          {
             using(StreamReader objSReader = new StreamReader(objStream))
             {                
                return new XmlTextReader(new StringReader(objSReader.ReadToEnd()));
             }//Dispose the StreamReader
          }//Dispose the Stream
       }//Dispose the WebRequest       
     }
