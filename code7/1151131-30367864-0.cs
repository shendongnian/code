    using (AH_ODS_DBEntities db = new AH_ODS_DBEntities())
    {
        //XML CustomerRefNbr            
        string[] allFiles = Directory.GetFiles(@"C:\xml\");
        foreach (var @CRN in allFiles)
        {
            XElement xEle = XElement.Load(@CRN);
            IEnumerable<XElement> invoices = xEle.Elements();
            foreach (XElement pEle in invoices)
            {
                string c = pEle.Element("CustomerRef").Value;
                //DB CustomerRefNbr
                IEnumerable<string> rs = db.Sales.AsQueryable().Select(crn => crn.CustomerRefNbr);
                foreach (string invoice in rs)
                {
                    if (invoice == c);
                        //This is a match
                }
            }
        }
    }
