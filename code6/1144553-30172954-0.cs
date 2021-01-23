    var atClauseList = new List<AtClause>();
    foreach(var item in doc.Descendants(CLAUSE_GROUP_TAG).Descendants(AT_CLAUSE_TAG))
    {
        var atClause = new AtClause();
 
        atClause.ClauseNumber = (string)item.Element("Number");
        var sponsor = item.Element("Sponsor");
        if (sponsor != null)
        {
               atClause.Sponsors = sponsor.Elements(SPONSOR_TAG).Select(y => y.Value).ToList();
               atClause.Page = sponsor.Element("aItem").Element("AmendText").Element("Page").ElementValueNull();
               atClause.Line = sponsor.Element("aItem").Element("AmendText").Element("Line").ElementValueNull();
               atClause.LineText = sponsor.Element("aItem").Element("AmendText").Nodes().OfType<XText>().FirstOrDefault().XTextValueNull();
               atClause.ItalicText = sponsor.Element("aItem").Element("AmendText").Element("Italic").ElementValueNull();
               atClause.ParaList = sponsor.Element("aItem").Element("AmendText").Elements("Para").Select(L => new Para
               {
                    ParaText = (string)L,
                    Number = ((System.Xml.Linq.XElement)(L)).AttributeValueNull("Number"),
                    Quote = ((System.Xml.Linq.XElement)(L)).AttributeValueNull("Quote"),
               }).ToList();
                
               atClauseList.Add(atClause);
         }
