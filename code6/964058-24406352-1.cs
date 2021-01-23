    static class LikeEvaluator
    {
    	private static readonly MethodInfo ApplyLikeMethodInfo=typeof(LikeEvaluator).GetMethod("ApplyLike");
    	private static readonly MethodInfo ApplyLikeNoCaseMethodInfo=typeof(LikeEvaluator).GetMethod("ApplyLikeNoCase");
    
    	public static Expression Like(CaseMode caseMode, Expression lhs, Expression pattern)
    	{
    		Expression x=null;
    		
    		if(caseMode==CaseMode.Sensitive)
    		{
    			x=Expression.Call(ApplyLikeMethodInfo,lhs,pattern);
    		}
    		else
    		{
    			x=Expression.Call(ApplyLikeNoCaseMethodInfo,lhs,pattern);
    		}
    
    		return x;
    	}
    
    	public static bool ApplyLike(string text, string likePattern)
    	{
    		string pattern=PatternToRegex(likePattern);
    		return Regex.IsMatch(text,pattern,RegexOptions.None);
    	}
    
    	public static bool ApplyLikeNoCase(string text, string likePattern)
    	{
    		string pattern=PatternToRegex(likePattern);
    		return Regex.IsMatch(text,pattern,RegexOptions.IgnoreCase);
    	}
    
    	public static string PatternToRegex(string pattern)
    	{
    		pattern=Regex.Escape(pattern);
    		pattern=pattern.Replace("%",@".*");
    		pattern=string.Format("^{0}$",pattern);
    		
    		return pattern;
    	}
    }
