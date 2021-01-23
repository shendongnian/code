    List<MatchedRegexObject> matchedRegexObj = new List<MatchedRegexObject>();
    //Populate matchedRegexObj
    MatchedRegexObject m = new MatchedRegexObject();
    m.Id = "id1";
    m.MatchedPart = "Matchpart1";
    m.RegExpression = "RegEx1";
    matchedRegexObj.Add(m);
    gvResult.DataSource = matchedRegexObj;
    gvResult.DataBind();
