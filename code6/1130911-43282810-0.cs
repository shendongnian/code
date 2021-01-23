    XmlTextReader myXmlReader;
    myWebService = new WebServiceImporterCompiler(WSDLPath, soapVersion);
    if (useLocalWSDL)
    {
         FileWebRequest wr = (FileWebRequest)FileWebRequest.Create(WSDLPath);
         FileWebResponse wres = (FileWebResponse)wr.GetResponse();
         myXmlReader = new XmlTextReader(wres.GetResponseStream());
    }
    else
    {
         Uri uri = new Uri(WSDLPath); //WEBSERVICE URI
         HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(uri.OriginalString + "?wsdl");
         wr.Credentials = wr.Credentials = new NetworkCredential(userName, password ?? "");
         HttpWebResponse wres = (HttpWebResponse)wr.GetResponse();
         myXmlReader = new XmlTextReader(wres.GetResponseStream());
    }
