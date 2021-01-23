    [StepArgumentTransformation]
    public IWebElement TransformToWebElementOnCurrentPage(string elementName)
    {
        object currentPage = ScenarioContext.Get("CurrentPage");
        //get the property of the current page with the given name
        var props = currentPage.GetType().GetProperties();
        return (IWebElement) props.First(x=>x.Name==elementName).GetValue(null);
    }
