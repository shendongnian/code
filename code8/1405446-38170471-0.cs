using System;
using System.Data.Services.Client;
using System.Net;
namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri grillUri =
                new Uri("http://grillassessmentservice.cloudapp.net/GrillMenuService.svc/",
                    UriKind.Absolute);
            ServiceReference1.GrillMenuContext context = new ServiceReference1.GrillMenuContext(grillUri);
            var serviceCreds = new NetworkCredential("jobs@isolutions.ch", "cleancode");
            var cache = new CredentialCache();
            cache.Add(grillUri, "Basic", serviceCreds);
            context.Credentials = serviceCreds;
            try
            {
                foreach (ServiceReference1.GrillMenuItem o in context.GrillMenuItems)
                    Console.WriteLine("Name: {0}", o.Name);                    
            }
            catch (DataServiceQueryException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
