    public List<BDO_Enquiry> GetEnquiryList()
    {
        List<BDO_Enquiry> retList = new List<BDO_Enquiry>();
        try
        {
            using (var context = new BDODevelopmentEntities())
            {
                try
                {
                    var query = context.BDO_Enquiry.Include("Child");
                    query = query.Include("AnotherChild");
                    retList = query.ToList();
                }
                catch (Exception ex) { string g = ""; }
            }
        } catch(Exception ex) { string h = ""; }
        return retList;
    }
