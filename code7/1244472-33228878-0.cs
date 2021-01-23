        static IEnumerable<T> GetPageItems<T>(List<List<T>> itemLists, int pageSize, int page)
        {
            if (page < 1)
            {
                return new List<T>();
            }
            // a simple copy so that we don't change the original (the individual Lists inside are untouched):
            var lists = itemLists.ToList();
            // Let's find the starting indexes for the first item on this page:
            var currItemIndex = 0;
            var currListIndex = 0;
            var itemsToSkipCount = pageSize * (page - 1); // <-- assuming that the first page is page 1, not page 0
            // I'll just break out of this loop manually, because I think this configuration actually makes
            // the logic below a little easier to understand.  Feel free to change it however you see fit :)
            while (true)
            {
                var listsCount = lists.Count;
                if (listsCount == 0)
                {
                    return new List<T>();
                }
                
                // Let's consider a horizontal section of items taken evenly from all lists (based on the length of
                // the shortest list).  We don't need to iterate any items in the lists;  Rather, we'll just count 
                // the total number of items we could get from this horizontal portion, and set our indexes accordingly...
                var shortestListCount = lists.Min(x => x.Count);
                var itemsWeAreConsideringCount = listsCount * (shortestListCount - currItemIndex);
                // Does this horizontal section contain at least as many items as we must skip?
                if (itemsWeAreConsideringCount >= itemsToSkipCount) 
                {   // Yes: So mathematically find the indexes of the first page item, and we're done.
                    currItemIndex += itemsToSkipCount / listsCount;
                    currListIndex = itemsToSkipCount % listsCount;
                    break; 
                }
                else
                {   // No: So we need to keep going.  Let's increase currItemIndex to the end of this horizontal 
                    // section, remove the shortest list(s), and the loop will continue with the remaining lists:
                    currItemIndex = shortestListCount;
                    lists.RemoveAll(x => x.Count == shortestListCount);
                    itemsToSkipCount -= itemsWeAreConsideringCount;
                }
            }
            // Ok, we've got our starting indexes, and the remaining lists that still have items in the index range.
            // Let's get our items from those lists:
            var pageItems = new List<T>();
            var largestListCount = lists.Max(x => x.Count);
            // Loop until we have enough items to fill the page, or we run out of items:
            while (pageItems.Count < pageSize && currItemIndex < largestListCount)
            {
                var currList = lists[currListIndex];
                // If the list has an element at this index:
                if (currItemIndex < currList.Count)
                {
                    pageItems.Add(currList[currItemIndex]);                    
                }
                // else... this list has no more elements.
                // We could throw away this list, since it's pointless to iterate over it any more, but that might 
                // change the indices of other lists...  for simplicity, I'm just gonna let it be... the above logic 
                // simply ignores it each time.
                currListIndex++;
                if (currListIndex == lists.Count)
                {
                    currListIndex = 0;
                    currItemIndex++;
                }
            }
            return pageItems;
        }
