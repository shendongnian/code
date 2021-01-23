    // Assumes you have a page object of type MyPage.
    // Note the default timeout for RetryingElementLocator is
    // 5 seconds, if unspecified.
    // The generic version of this code looks like this:
    // MyPage page = PageFactory.InitElements<MyPage>(new RetryingElementLocator(driver), TimeSpan.FromSeconds(10));
    MyPage page = new MyPage();
    PageFactory.InitElements(page, new RetryingElementLocator(driver, TimeSpan.FromSeconds(10))); 
