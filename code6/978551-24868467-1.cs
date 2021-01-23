    var finder = new NativeElementFinder(
    () => browser.Body.NativeElement.AllDescendants,
    browser.DomContainer,
    new[] { ElementTag.Any },
    Find.By("href", new System.Text.RegularExpression.Regex(@"*account-details.go?adx*")));
    LinkCollection lc = new LinkCollection(browser.DomContainer, finder);
