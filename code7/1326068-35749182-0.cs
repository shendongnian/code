    public IWebElement FindElementByMultipleCriteria(List<By> Criteria, IReadOnlyCollection<IWebElement> toFilter = null)
    {
        // If we've reached the end of the criteria list, return the first element:
        if (Criteria.Count == 0 && toFilter != null) return toFilter.ElementAt(0);
        // Take the head of the criteria list
        By currentCriteria = Criteria[0];
        Criteria.RemoveAt(0);
        // If no list of elements found exists, we get all elements from the current criteria:
        if (toFilter == null)
        {
            toFilter = Driver.FindElements(currentCriteria);
        }
        // If a list does exist, we must filter out the ones that aren't found by the current criteria:
        else
        {
            List<IWebElement> newFilter = new List<IWebElement>();
            foreach(IWebElement e in Driver.FindElements(currentCriteria))
            {
                if (toFilter.Contains(e)) newFilter.Add(e);
            }
            toFilter = newFilter.AsReadOnly();
        }
        // Pass in the refined criteria and list of elements found.
        return FindElementByMultipleCriteria(Criteria, toFilter);
    }
