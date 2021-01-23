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
                using (AH_ODS_DBEntities db = new AH_ODS_DBEntities())
                {
                    List<string> rs = db.Sales.Where(s => s.CustomerRefNbr == c).ToList();
                    if (rs.Any())
                    {
                        //all items in rs are matches
                    }
                }
            }
        }
