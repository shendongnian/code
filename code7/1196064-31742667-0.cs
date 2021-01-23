        public List<wsQuote> GetAllTrucks(string truckID)
        {
            NorthwindDataContext dc = new NorthwindDataContext();
            List<wsQuote> results = new List<wsQuote>();
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            foreach (tblQuote quote in dc.tblQuotes.Where(s => s.ID.ToString() == truckID))
            {
                results.Add(new wsQuote()
                    {
                        QuoteID = quote.ID,
                        QuoteNumber = quote.QUOTENUMBER
                    });
                // return results; <----- HERE! Move this to after the loop
            }
            return results; // Move it here.
        }
