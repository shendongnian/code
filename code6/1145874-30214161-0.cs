    using System.Net;
    using System.IO;
    using System.Xml;
    using System.Collections.Specialized;
    
    public class CountryIP {
    	public string GetCountryByIP(string ipAddress) {
    	  string ipResponse = IPRequestHelper("http://ipinfodb.com/ip_query_country.php?ip=", ipAddress);
    	  
    	  XmlDocument ipInfoXML = new XmlDocument();
    	  ipInfoXML.LoadXml(ipResponse);
    	  XmlNodeList responseXML = ipInfoXML.GetElementsByTagName("Response");
    	  
    	  NameValueCollection dataXML = new NameValueCollection();
    	  
    	  dataXML.Add(responseXML.Item(0).ChildNodes(2).InnerText, responseXML.Item(0).ChildNodes(2).Value);
    	  
    	  string xmlValue = dataXML.Keys(0);
    	  
    	  return xmlValue;
    	}
    	
    	public string IPRequestHelper(string url, string ipAddress) {
    	  string checkURL = url + ipAddress;
    		
    	  HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
    	  HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
    	  
    	  StreamReader responseStream = new StreamReader(objResponse.GetResponseStream());
    	  string responseRead = responseStream.ReadToEnd();
    	  
    	  responseStream.Close();
    	  responseStream.Dispose();
    	  
    	  return responseRead;
    	}
    }
