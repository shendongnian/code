    public class CommandLineArgs
    {
        [Option('t', "type", Required = false, HelpText = "Type of the application [safedispatch, safenet]")]
        public string AppType { get; set; }
        [Option('c', null, HelpText = "Enable the console for this application")]
        public bool Console { get; set; }
        [Option('l', null, HelpText = "Enable the logs for this application")]
        public bool Log { get; set; }
        [Option('h', null, HelpText = "Help for this command line")]
        public bool Help { get; set; }
        [HelpOption]
        public string GetUsage()
        {
            // this without using CommandLine.Text
            //  or using HelpText.AutoBuild
            var usage = HelpText.AutoBuild(this);
        
            return usage.ToString();
        }
    }
