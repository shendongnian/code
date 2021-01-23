    var campaignCriterionService = (CampaignCriterionService)user.GetService(AdWordsService.v201601.CampaignCriterionService);
    int offset = 0;
    int pageSize = 500;
    var page = new CampaignCriterionPage();
                
    try
    {
        do
        {
            page = campaignCriterionService.get(new Selector
            {
                fields = new string[] { IpBlock.Fields.Id, IpBlock.Fields.IpAddress },
                predicates = new Predicate[]
                {
                    new Predicate
                    {
                        field = IpBlock.Fields.CriteriaType,
                        @operator = PredicateOperator.EQUALS,
                        values = new string[] { "IP_BLOCK" }
                    }
                }
            });
            // Display the results.
            if (page != null && page.entries != null)
            {
                int i = offset;
                foreach (var item in page.entries)
                {
                    var t = item; //my work logic here ....                           
                    i++;
                }
            }
            offset += pageSize;
        } while (offset < page.totalNumEntries);
        Debug.WriteLine("Number of items found: {0}", page.totalNumEntries);
    }
    catch (Exception e)
    {
        throw new System.ApplicationException("Failed to retrieve campaigns", e);
    }
