    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    
    
    /// <summary>
    /// Fetches a Web Page
    /// </summary>
    class WebFetch
    {
    	static void Main(string[] args)
    	{
    		HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://www.nbcwashington.com/weather/school-closings/");
    
    		HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    
    		Stream rawStream = response.GetResponseStream();
    
    		string resOutput = String.Empty();
    
    		using (StreamReader reader = new StreamReader(rawStream))
    		{
    			resOutput = reader.ReadToEnd();
    		}
    
    		Console.WriteLine(resOutput);
    		Console.Clear();
    
    		string searchForThis = "Open";
    		int firstCharacter = resOutput.IndexOf(searchForThis);
    		Console.WriteLine(resOutput.IndexOf(searchForThis))
    		Console.ReadLine();
            response.Close();
    	}
    }
