    <serverlist>
      <add name="CollectorServer" value="127.0.0.1"/>
    </serverlist>
    NameValueCollection address =  
    ConfigurationManager.GetSection("serverlist")
    as System.Collections.Specialized.NameValueCollection;
    if (address != null)
    {
        foreach (string key in address.AllKeys)
        {
           Response.Write(key + ": " + address[key] + "<br />");
        }
    }
