    var isNotFound = false;
    try {
        objCortextResult = GetCortextUserInformation(tstrProperty, tstrPropertyValue);
    }
    catch(WebException ex) {
        if(((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.NotFound)       
        {
            isNotFound = true;
        }
        else {
            throw;
        }
    }
    if (isNotFound) continue;
    ...
