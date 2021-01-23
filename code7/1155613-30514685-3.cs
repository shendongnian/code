    [HttpPost]
    [Route("SearchLead")]
    public IEnumerable<LeadSearchResult> PostCriteria([FromBody]LeadSearchCriteria criteria)
    {
        List<LeadSearchResult> list = new List<LeadSearchResult>() { new LeadSearchResult { ProductID = 1, Result = 12 }, new LeadSearchResult { ProductID = 2, Result = 22 } };
        return list.Where(x => x.ProductID == criteria.ProductID);
    }
