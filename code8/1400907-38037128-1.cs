    using System;
    using System.Net;
    
    class Program
    {
        static void Main()
        {
    	using (WebClient client = new WebClient())
    	{
    
    	    // Download data.
    	    byte[] arr = client.DownloadData("http://url-to-your-pdf-file.com/file1");
    
    	    // Write values.
    	    Console.WriteLine("--- WebClient result ---");
    	    Console.WriteLine(arr.Length);
    	}
        }
    }
