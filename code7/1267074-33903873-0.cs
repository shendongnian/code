    try {
        objCortextResult = GetCortextUserInformation(tstrProperty, tstrPropertyValue);
    }
    catch(WebException ex) {
        if(((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.NotFound) continue;
        throw;
    }
