    XDocument doc = new XDocument
                     (
                           new XDeclaration("1.0", "utf-8", "yes"),
                               new XComment("Question Configuration"),
    						   new XElement("AnswerData", GetAnswerData(viewmodel));
    						
    public List<XElement> GetAnswerData(Object viewmodel)
    {
    	var result = new List<XElement>();
    
    	for(int x =0 ; x < viewmodel[i].MultiAnswer.Count(); x++)
    	{
    		result.Add(new XElement("Answer",viewmodel[i++].MultiAnswer[x])));
    	}
    	return result;
    }
