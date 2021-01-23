    // You MUST send a subscription request first! Otherwise there won't be
    // any cookies to examine.
    exchangeService.SubscribeToStreamingNotifications(foldersToSubscribeTo, EventsToSubscribeTo);
    // Get a string of all the cookies
    var allCookies = exchangeService.CookieContainer.GetCookieHeader(exchangeService.Url);
    Console.WriteLine(allCookies);
    // Or get a specific cookie
    var cookies = exchangeService.CookieContainer.GetCookies(exchangeService.Url);
    var xBackEndOverrideCookie = cookies["X-BackEndOverrideCookie"];
    Console.WriteLine(XBackEndOverrideCookie);
