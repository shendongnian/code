    catch (WebException e)
    {
        var response = ((HttpWebResponse)e.Response);
        var someheader = response.Headers["X-API-ERROR"];
        // check header
        var content = response.GetResponseStream();
        // check the content if needed 
        if (e.Status == WebExceptionStatus.ProtocolError)
        {
            // protocol errors find the statuscode in the Response
            // the enum statuscode can be cast to an int.
            int code = (int) ((HttpWebResponse)e.Response).StatusCode;
            // do what ever you want to store and return to your callers
        }
    }
