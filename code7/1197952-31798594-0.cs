    public class RegularExpressionOnListElements : RegularExpressionAttribute
    {
        public RegularExpressionOnListElements(string pattern)
	    	: base(pattern)
	    {
	    }
    	public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list != null)
            {
                return list.All(elem => base.IsValid(elem));
            }
            return true;
        }
    }
