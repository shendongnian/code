    public static MvcHtmlString ValidationSummaryLimited(this HtmlHelper helper,
    	bool excludePropertyErrors)
    {
    	MvcHtmlString result = helper.ValidationSummary(excludePropertyErrors);
    	return LimitSummaryResults(result);
    }
    
    private static MvcHtmlString LimitSummaryResults(MvcHtmlString summary)
    {
    	if (summary == null || summary.ToString() == string.Empty)
    		return summary;
    
    	int maximumValidations = RVConstants.MaximumValidationErrors;
    	
    	Regex exp = new Regex(@"<li[^>]*>[^<]*</li>",RegexOptions.IgnoreCase);
    
    	string htmlString = summary.ToHtmlString();
    	MatchCollection matches = exp.Matches(htmlString);
    
    	if (matches.Count > maximumValidations)
    	{
    		string header = htmlString.Substring(0, htmlString.IndexOf("<ul>",StringComparison.Ordinal) + "<ul>".Length);
    		string footer = htmlString.Substring(htmlString.IndexOf("</ul>", StringComparison.Ordinal));
    
    		StringBuilder sb = new StringBuilder(htmlString.Length);
    		sb.Append(header);
    
    		for (int i = 0; i < maximumValidations; i++)
    		{
    			sb.Append(matches[i].Value);
    		}
    
    		sb.AppendFormat("<li>Maximum of {0} errors shown</li>", maximumValidations);
    
    		sb.Append(footer);
    
    		string limited = sb.ToString();
    		return new MvcHtmlString(limited);
    	}
    
    	return summary;
    }
