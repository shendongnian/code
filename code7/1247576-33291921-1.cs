    public bool Method(List<string> testingValues, IList<IWebElement> Element, IList<IWebElement> Element2)
    {
         return testingValues.All(item => Element.Any(x => x.Text==item)
                                        ||Element2.Any(y => y.Text==item));
    }
