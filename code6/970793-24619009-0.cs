    using System;
    using Microsoft.SharePoint.Client;
    class DisplayWebTitle
    {
        static void Main()
        {
            ClientContext clientContext = new ClientContext("http://intranet.contoso.com");
            Web site = clientContext.Web;
            clientContext.Load(site);
            clientContext.ExecuteQuery();
            Console.WriteLine("Title: {0}", site.Title);
        }
    }
