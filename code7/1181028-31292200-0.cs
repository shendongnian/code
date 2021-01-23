    namespace Any.Contact
    {
        using System.Threading.Tasks;
        using System.Web.Services;
    
        public partial class ContactFormPage : PublishingLayoutPage
        {    
            [WebMethod]
            public static bool SendMessage(string topic, string message)
            {
                return SendEmail(topic, message);
            }
        }
    }
