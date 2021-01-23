    bool ValidateImage(string url)
    {
        HttpWebRequest r = (HttpWebRequest)WebRequest.Create(url);
        
        r.Method = "GET";
        
        try
        {
            HttpWebResponse resp = (HttpWebResponse)r.GetResponse();
            
            if (resp.ContentType == "image/jpeg")
            {
                Console.WriteLine("Image retrieved successfully.");
                // Process image
                return true;
            }
            else 
            {
                Console.WriteLine("Unable to retrieve image");
            }
        }
        catch
        {
            Console.WriteLine("Unable to retrieve image.");
        }
        return false;
    }
