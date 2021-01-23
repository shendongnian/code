    string condsCats = EzCoding.Web.UI.QueryStringParsing.GetValue("CondsCats",EzCoding.Web.RequestMethod.Post);
    string[] seledCats = null;
    if(condsCats != null)
        seledCats = condsCats 
            .Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
            .Select(s => String.Format("'{0}'", s))
            .ToArray();
