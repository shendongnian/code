    public class LicenseInfo
    {
        public string Info1 { get; private set; }
        public bool IsValid
        {
            get
            {
                // todo, add logic here
                return true;
            }
        }
        public bool ParseLicense(string data)
        {
            bool ret = false;
            if (data != null)
            {
                // todo, parse data and set status/attributes/etc
                Info1 = data;
                ret = true;
            }
            return ret;
        }
    }
    // could make a static class...
    public class License
    {
        public LicenseInfo GetLicenseInfo()
        {
            var license = new LicenseInfo();
            // todo: create whatever schema you want.
            // filename hard-coded per app/version/etc.
            // file could contain text/json/etc.
            // easy to manage, update, etc.
            // extensible.
            var uri = "https://raw.githubusercontent.com/korygill/Demo-License/master/StackOverflow-Demo-License.txt";
            var request = (HttpWebRequest)HttpWebRequest.Create(uri);
            var response = request.GetResponse();
            var data = new StreamReader(response.GetResponseStream()).ReadToEnd();
            license.ParseLicense(data);
            return license;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // check if our license if valid
            var license = new License();
            var licenseInfo = license.GetLicenseInfo(); 
            if (!licenseInfo.IsValid)
            {
                Console.WriteLine("Sorry...license expired.");
                Environment.Exit(1);
            }
            Console.WriteLine("You have a valid license.");
            Console.WriteLine($"{licenseInfo.Info1}");
        }
    }
