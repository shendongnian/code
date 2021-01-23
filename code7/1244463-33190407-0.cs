        static IEnumerable<int> GetPageItems(IEnumerable<List<int>> itemLists, int pageSize, int page)
        {
            var mergedOrderedItems = itemLists.SelectMany(x => x.Select((s, index) => new { s, index }))
                                              .GroupBy(x => x.index)
                                              .SelectMany(x => x.Select(y => y.s));
            
            // assuming that the first page is page 1, not page 0:
            var startingIndex = pageSize * (page - 1);
                        
            var pageItems = mergedOrderedItems.Skip(startingIndex)
                                              .Take(pageSize);
            return pageItems;            
        }
