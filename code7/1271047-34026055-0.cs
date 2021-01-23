    try
    {
        IUIItem menuItem = menu.Get(SearchCriteria.ByText(criteria));
        menuItem.Click();
    }
    catch (Exception ex)
    {
    }
