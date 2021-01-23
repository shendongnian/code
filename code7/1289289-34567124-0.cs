    using System.Collections.Specialized;
    using System.Web;
    
    <...>
    
    const string InitialQueryString = "?key=123&toke=64323sac&con=1";
    // 1. Parsing.
    NameValueCollection queryStringValues = HttpUtility.ParseQueryString(InitialQueryString);
    // 2. Changing.
    // The additional values can be added.
    queryStringValues.Add("custom_key", "custom_value");
    // The existing values can be removed using their keys.
    if (the_condition)
    {
	    queryStringValues.Remove("con");
    }
    // 3. Building.
    string queryString = queryStringValues.ToString();
