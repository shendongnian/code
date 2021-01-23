    static void Main(string[] args)
    {
        var path = AssemblyDirectory + @"\external\";
        var files = Directory.GetFiles(path); //get all files
        var ad = AppDomain.CreateDomain("ProbingDomain"); //create another AppDomain
        var tunnel = (AppDomainTunnel)
            ad.CreateInstanceAndUnwrap(typeof (AppDomainTunnel).Assembly.FullName,
            typeof (AppDomainTunnel).FullName); //create tunnel
        var valid = tunnel.GetValidFiles(files); //pass file paths, get valid ones back
        foreach (var file in valid)
        {
            var asm = Assembly.LoadFile(file); //load valid assembly into the main AppDomain
            //do something
        }
        AppDomain.Unload(ad); //unload probing AppDomain
    }
    private class AppDomainTunnel : MarshalByRefObject 
    {   
        public string[] GetValidFiles(string[] files) //this will run in the probing AppDomain
        {
            var valid = new List<string>();
            foreach (var file in files)
            {
                try
                {   //try to load and search for valid types
                    var asm = Assembly.LoadFile(file);
                    if (asm.GetTypes().Any(x => x.IsSubclassOf(typeof (Rule1))))
                        valid.Add(file); //valid assembly found
                }
                catch (Exception)
                {
                    //ignore unloadable files (non .Net, etc.)
                }
            }
            return valid.ToArray();
        }
    }
    //found here: http://stackoverflow.com/a/283917/4035472
    public static string AssemblyDirectory
    {
        get
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
