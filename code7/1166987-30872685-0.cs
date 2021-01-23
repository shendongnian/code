     XDocument doc = new XDocument
     (
           new XDeclaration("1.0", "utf-8", "yes"),
               new XComment("Question Configuration"),
               new XElement("AnswerData", GetAnswerData(viewmodel));
        //...
    public IEnumerable<XElement> GetAnswerData(Object viewmodel)
    {
        for(int x =0 ; x < viewmodel[i].MultiAnswer.Count(); x++)
        {
            yield return new XElement("Answer",viewmodel[i++].MultiAnswer[x]));
        }
        yield break;
    }
