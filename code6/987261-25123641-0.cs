    public bool VerifyEmail(string e)
    {
         string email = e;
          //Grab element values that match the Email attribute in XML file
          XElement root = XElement.Load(bdConfigFile);
          return root.Elements().Any(el => (string)el.Attribute("Email") == email);
    }
