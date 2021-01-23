    using Microsoft.Framework.OptionsModel;
    public class MailHelper
    {
	    public MailHelper(IOptions<AwsSettings> awsOptionsAccessor)
	    {
		    awsSettings = awsOptionsAccessor.Options;
	    }
	    private AwsSettings awsSettings;
	
	    ... your other methods
    }
