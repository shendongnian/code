public class SoapServiceClient : Soap12ServiceClient
{
    public SoapServiceClient(string uri) : base(uri)
    {
        if (uri.StartsWithIgnoreCase("https://"))
        {
            var binding = (WSHttpBinding)base.Binding;
            binding.Security.Mode = SecurityMode.Transport;
        }
    }
}
