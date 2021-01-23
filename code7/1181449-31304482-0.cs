    private static void Successful(string basestring)
    {
    	object dynamo = new ExpandoObject();
    	IDictionary<string, object> dynamoose = dynamo as IDictionary<string, object>;
    	string[] words = basestring.Split(new char[]
    	{
    		'|'
    	});
    	string[] array = words;
    	for (int i = 0; i < array.Length; i++)
    	{
    		string word = array[i];
    		dynamoose[word] = word.ToUpperInvariant();
    	}
    }
    private static void Failed(string basestring)
    {
    	object dynamo = new ExpandoObject();
    	string[] words = basestring.Split(new char[]
    	{
    		'|'
    	});
    	string[] array = words;
    	for (int i = 0; i < array.Length; i++)
    	{
    		string word = array[i];
    		if (Program.<GetValue1>o__SiteContainer0.<>p__Site1 == null)
    		{
    			Program.<GetValue1>o__SiteContainer0.<>p__Site1 = CallSite<Func<CallSite, object, string, string, object>>.Create(Binder.SetIndex(CSharpBinderFlags.None, typeof(Program), new CSharpArgumentInfo[]
    			{
    				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
    				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
    				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
    			}));
    		}
    		Program.<GetValue1>o__SiteContainer0.<>p__Site1.Target(Program.<GetValue1>o__SiteContainer0.<>p__Site1, dynamo, word, word.ToUpperInvariant());
    	}
    }
