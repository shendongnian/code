    public class IgnoreAccentComparer:IEqualityComparer<string>
    {
    	public bool Equals(string left, string right)
    	{
    		if(left == null || right == null)
            {
               return false;
            }
    		return string.Equals(RemoveDiacritics(left), RemoveDiacritics(right));
    	}
    	public int GetHashCode(string txt)
    	{
    		return RemoveDiacritics(txt).GetHashCode();
    	}
    	static string RemoveDiacritics(string text)
    	{
    		string formD = text.Normalize(NormalizationForm.FormD);
    		StringBuilder sb = new StringBuilder();
    		
    		foreach (char ch in formD)
    		{
    			UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
    			if (uc != UnicodeCategory.NonSpacingMark)
    			{
    			sb.Append(ch);
    			}
    		}
    		
    		return sb.ToString().Normalize(NormalizationForm.FormC);
    	}
    }
