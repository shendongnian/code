    List<Content> ContentList = new List<Content>() 
                            { new Content { CreatedDate = DateTime.Now, Summary = new List<string>() { "America", "Pakistan", "India", "England" } }, 
                              new  Content { CreatedDate = DateTime.Now, Summary = new List<string>() { "Germany", "Holland", "Aus", "NewZealand" } }};
        
    DomainQuery domainQuery = new DomainQuery { CreatedAfter = DateTime.Now.AddDays(-4), PhrasesExcludeAll = new List<string>() { "Aus" }, CreatedBefore = DateTime.Now, PhrasesIncludeAll = new List<string>() { "America", "Pakistan", "India", "England" }, PhrasesIncludeAny = new List<string>() { "India" } };
        
    var result = ContentList.Where(c => domainQuery.PhrasesIncludeAny
                            .Any(item => c.Summary.Any(subItem => subItem == item))
               && !domainQuery.PhrasesExcludeAll.Any(item => c.Summary.Any(subItem => subItem == item))
               && !c.Summary.Except(domainQuery.PhrasesIncludeAll).Any()
               && c.CreatedDate < domainQuery.CreatedBefore
               && c.CreatedDate > domainQuery.CreatedAfter);
            foreach (var res in result)
            {
                res.Summary.ForEach(r => {
                        Console.WriteLine(r);
                    });
            }
            Console.ReadKey();
