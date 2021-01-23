    using System;
    using System.Net;
    using System.IO;
    
    class Program
    {
        static void Main()
        {
    	using (WebClient client = new WebClient())
    	{
    
    	    // Download data.
    	    byte[] arr = client.DownloadData("http://url-to-your-pdf-file.com/file1");
    
    	    File.WriteAllBytes(path_to_your_app_data_folder, arr)
    	}
        }
    }
