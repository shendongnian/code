    public partial class Service : System.Web.Services.Protocols.SoapHttpClientProtocol 
        {                    
                    public Service() 
                    {
                        this.Url = "http://xxx/service.asmx";
                    }
                    
                    public Service(string url) 
                    {
                        this.Url = url;
                    }
        }
