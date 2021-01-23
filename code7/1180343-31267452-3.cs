    //change from void to Quote
    public Quote GetLastQuote()
    {
        using (TruckDb db = new TruckDb())
        {
            var quote = (from qData in db.Quotes
                         where qData.Id == qData.RepresetativeId
                         orderby qData.Id descending
                         select qData).First();
            //new
            return quote;
        }
    }
