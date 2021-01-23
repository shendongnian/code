    using System.Threading;
    using System.Threading.Tasks;
    ...
    
    Parallel.ForEach(links, (currentLink) => 
                                {
                                    // Check "currentLink"
                                });
    // All links are checked at this point
