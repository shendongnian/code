    try
    {
        HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://httpstat.us/500");
        using (HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse())
        {
            myHttpWebResponse.Close();
            int code = (int)myHttpWebResponse.StatusCode;
            if (code == 200)
            {
                Console.WriteLine("success");
            }
            else
            {
                Console.WriteLine("success with code {0}", code);
            }
        }
    }
    catch (WebException e)
    {
        if (e.Status == WebExceptionStatus.ProtocolError)
        {
            // protocol errors find the statuscode in the Response
            // the enum statuscode can be cast to an int.
            int code = (int) ((HttpWebResponse)e.Response).StatusCode;
            throw new Exception(string.Format("Status code {0} ", code)); 
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
