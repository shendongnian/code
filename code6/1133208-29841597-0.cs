     HttpWebResponse httpResponse = null;
    try
    {
        httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            string result = streamReader.ReadToEnd();
            Console.WriteLine(result);
        }
    }
    catch (HttpException e)
    {
        Console.WriteLine(e.ToString());
    }
    catch (Exception e)
    {
        Console.WriteLine(e.ToString());
    }
