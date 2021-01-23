    public class MarginRep
        {
            public string mgnGrpCod { get; set; }
            public string mgnClsCod { get; set; }
            public string mgnPremiumAmnt { get; set; }
            public string mgnLiqDlvAmnt { get; set; }
            public string mgnSprdAmnt { get; set; }
            public string mgnAddlAmnt { get; set; }
            public string unadjMgnReq { get; set; }
    
            public override string ToString()
            {
                return string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}",
                 mgnGrpCod, mgnClsCod, mgnPremiumAmnt, mgnLiqDlvAmnt, mgnSprdAmnt,
                 mgnAddlAmnt, unadjMgnReq);
            }
        }
        var xmlDoc = XDocument.Load("1.xml");
        XNamespace xn = xmlDoc.Root.Name.Namespace;
        IEnumerable<MarginRep> myMarginRep = xmlDoc.Root.Descendants(xn + "pp010Rec")
        .Select(c => new MarginRep()
            {
                mgnGrpCod = c.Element(xn + "mgnGrpCod").Value,
                mgnClsCod = c.Element(xn + "mgnClsCod").Value,
                mgnPremiumAmnt = c.Element(xn + "mgnPremiumAmnt").Value,
                mgnLiqDlvAmnt = c.Element(xn + "mgnLiqDlvAmnt").Value,
                mgnSprdAmnt = c.Element(xn + "mgnSprdAmnt").Value,
                mgnAddlAmnt = c.Element(xn + "mgnAddlAmnt").Value,
                unadjMgnReq = c.Element(xn + "unadjMgnReq").Value
            });
        foreach (var x in myMarginRep)
            Console.WriteLine(x);
