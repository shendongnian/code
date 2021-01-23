	public class CommandLineOptions
	{
	    public const bool CASE_INSENSITIVE = false;
	    public const bool CASE_SENSITIVE = true;
	    public const bool MUTUALLY_EXCLUSIVE = true;
	    public const bool MUTUALLY_NONEXCLUSIVE = false;
	    public const bool UNKNOWN_OPTIONS_ERROR = false;
	    public const bool UNKNOWN_OPTIONS_IGNORE = true;
	
	    public CommandLineOptions();
	
	    public string[] AboutText { get; set; }
	    [ParserState]
	    public IParserState LastParserState { get; set; }
	
	    [HelpOption(HelpText = "Display this Help Screen")]
	    public virtual string GetUsage();
	    public bool ParseCommandLine(string[] Args);
	    public bool ParseCommandLine(string[] Args, bool IgnoreUnknownOptions);
	    public bool ParseCommandLine(string[] Args, bool IgnoreUnknownOptions, bool EnableMutuallyExclusive);
	    public bool ParseCommandLine(string[] Args, bool IgnoreUnknownOptions, bool EnableMutuallyExclusive, bool UseCaseSensitive);
	}
