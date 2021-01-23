    public static CurrentApp LoadCurrentApp(string productKey = "Premium", bool isActive = false, bool isTrial = false)
        {
            CurrentApp currentApp = new CurrentApp();
            currentApp.LicenseInformation = new LicenseInformation()
            {
                App = new App()
                {
                    AgeRating = "3",
                    AppId = BasicAppInfo.AppId,
                    CurrentMarket = "en-us",
                    LinkUri = "",
                    MarketData = new MarketData()
                    {
                        Name = "In-app purchases",
                        Description = "AppDescription",
                        Price = "5.99",
                        CurrencySymbol = "$",
                        CurrencyCode = "USD",
                    }
                },
                Product = new Product()
                {
                    ProductId = productKey,
                    MarketData = new MarketData()
                    {
                        Lang = "en-us",
                        Name = productKey,
                        Description = "AppDescription",
                        Price = "5.99",
                        CurrencySymbol = "$",
                        CurrencyCode = "USD",
                    }
                }
            };
            currentApp.ListingInformation = new ListingInformation()
            {
                App = new App()
                {
                    IsActive = isActive.ToString(),
                    IsTrial = isTrial.ToString(),
                },
                Product = new Product()
                {
                    ProductId = productKey,
                    IsActive = isActive.ToString(),
                }
            };
            return currentApp;
        }
