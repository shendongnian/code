    // Build name value pairs for the incoming web hook from Twilio
    NameValueCollection nvc = Request.Form;
    // Type the name value pairs
    string strFrom = nvc["From"];
    string strNumMedia = nvc["NumMedia"];
    string strBody = nvc["Body"];
    
    // Holds the image type and link to the images
    List<string> listMediaUrl = new List<string>();
    List<string> listMediaType = new List<string>();
    List<Stream> listImages = new List<
    
    // Find if there was any multimedia content
    
    if (int.Parse(strNumMedia) != 0) {
      // If there was find out the media type and the image url so we can pick them up
      for (int intCount = 0; intCount < int.Parse(strNumMedia);) {
        // Store the media type for the image even through they should be the same
        listMediaType.Add(nvc[("MediaContentType" + intCount).ToString()]);
        // Store the image there is a fair chance of getting more then one image Twilio supports 10 in a single MMS up to 5Mb
        listMediaUrl.Add(nvc[("MediaUrl" + intCount).ToString()]);
        // Update the loop counter
        intCount = intCount + 1;
      }
    }
