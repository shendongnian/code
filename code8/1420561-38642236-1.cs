    public class BuildActionFactory
    {
    	private static IDictionary<string, BuildAction> _buildActions =
    		new Dictionary<string, BuildAction>()
    		{
    			{"BUILDTEST", typeof(BuildTest)},
    			{"CHANGEROLE", typeof(ChangeRole)},
    			{"CHECKOUTDATA", typeof(CheckoutData)}
    		};
    
    	public static BuildAction CreateBuildAction(string directive)
    	{
    		return _buildActions.ContainsKey(directive) ?
    			Activator.CreateInstance(_buildActions[directive]) :
    			null;
    	}
    
    	public static string BuildReadme()
    	{
    		return string.Join(Environment.NewLine + Environment.NewLine,
    			new [] {"FUNCTIONALITY"}.Union(_buildActions.Select(pair => pair.Key + ": " + pair.Value.Description));
    	}
    }
