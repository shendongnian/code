    using (WebClient wc = new WebClient())
    {   
       try
       {
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            HtmlResult = wc.UploadString(URI, myParameters);
            if (some failed condition)
            {
               // I don't know what actually throws this, this is just for sim purposes
               throw new AuthenticateExeption("I can not connect");
            }
        }
        catch(AuthenticateExeption a)
        {
            // handle the exception
            Log(a.Message) // etc....
        }
        catch(Exception e)
        {
           // handle all other exceptions
        }
    }
