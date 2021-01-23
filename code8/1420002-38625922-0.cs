    try
    {
    	WebRequest request = WebRequest.Create(url);
    	WebResponse response = request.GetResponse();
    	string originalFileName = response.ResponseUri.AbsolutePath.Substring(response.ResponseUri.AbsolutePath.LastIndexOf("/") + 1);
    	Stream streamWithFileBody = response.GetResponseStream();
    	using (Stream output = File.OpenWrite(@"C:\MyPath\" + originalFileName))
    	{
    		streamWithFileBody.CopyTo(output);
    	}
    
    	Console.WriteLine("Downloded : " + originalFileName);
    }
    catch (Exception ex)
    {
    	Console.WriteLine("Unable to Download : " + ex.ToString());
    }
