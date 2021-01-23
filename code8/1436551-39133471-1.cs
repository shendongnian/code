    static void Versioncheck (double currentVersion)
        {
            //Get web response of git repository (/latest will forward you to the latest version)
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://github.com/forReason/Humanizer/releases/latest");
            req.Method = "HEAD";
            req.AllowAutoRedirect = true;
            WebResponse response = (HttpWebResponse)req.GetResponse();
            //split the parts of the responseuri
            string responseUri = response.ResponseUri.ToString();
            string[] uriParts = responseUri.Split('/');
            //compare the latest part of the versionuri (version number) with the currect program version
            if (Convert.ToDouble(uriParts.Last(), CultureInfo.InvariantCulture) > currentVersion)
            {
                Console.WriteLine("Version " + uriParts.Last() + " is available! You can get the latest Version here:");
                Console.WriteLine("Project download page");
            }
            else
            {
                Console.WriteLine("Congrats! You are using the newest Version of programname!");
            }
        }
