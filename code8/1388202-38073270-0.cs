    // get all categories from eBay
                        ApiContext context = GetApiContext();
                        GetCategoriesCall apiCall = new GetCategoriesCall(context)
                        {
                            EnableCompression = true,
                            ViewAllNodes = true
                        };
                        apiCall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll);
                        apiCall.GetCategories();
        public static ApiContext GetApiContext()
        {
            //apiContext is a singleton,
            //to avoid duplicate configuration reading
            if (apiContext != null)
            {
                return apiContext;
            }
            else
            {
                apiContext = new ApiContext();
                //set Api Server Url
                apiContext.SoapApiServerUrl = "https://api.ebay.com/wsapi";
                //set Api Token to access eBay Api Server
                ApiCredential apiCredential = new ApiCredential();
                apiCredential.eBayToken ="YOUR_TOKEN";
                apiContext.ApiCredential = apiCredential;
                //set eBay Site target to US
                apiContext.Site = eBay.Service.Core.Soap.SiteCodeType.US;
                return apiContext;
            }
        }
