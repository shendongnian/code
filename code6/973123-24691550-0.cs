    public class TestClass
    {
        public static void Main(string[] args)
        {
            bool isEqual = DownloadString("www.abc.com") == DownloadString("www.xyz.com")
            // do whatever you want with it
        }    
        private static string DownloadString(string address)
        {
            using (WebClient client = new WebClient())
        	{
                return client.DownloadString(address);
            }
        }
    }
