    /// <summary>
	/// Retrieves the list of fonts currently served by the Google Fonts Developer API
	/// Documentation: https://developers.google.com/fonts/docs/developer_api/v1/webfonts/list
	/// </summary>
	/// <param name="service">Valid authentcated WebfontsService</param>
	 /// <returns></returns>
	 public static WebfontList list(WebfontsService service)
	 {
	  try
        {
            var request = service.Webfonts.List();
	  return  request.Execute();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Request Failed " + ex.Message);
            throw ex;
        }
	 
	 
	 }
