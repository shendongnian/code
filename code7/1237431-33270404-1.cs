	public class ApplicationCommandLine : CommandLineOptions
	{
	    [Option('d', "download", HelpText = "Download Items before running")]
	    virtual public bool Download { get; set; }
	
	    [Option('g', "generate", HelpText = "Generate Mode (Generate New Test Results)", MutuallyExclusiveSet = "Run-Mode")]
	    virtual public bool GenerateMode { get; set; }
	
	    [Option('r', "replay", HelpText = "Replay Mode (Run Test)", MutuallyExclusiveSet = "Run-Mode")]
	    virtual public bool ReplayMode { get; set; }
	}
