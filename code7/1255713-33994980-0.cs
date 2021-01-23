        public static void test()
        {
            string accessToken = "12432543252345";
            string accessTokenSecret = "5b1cb122b340db43d4bae6bb880c8a284499";
            string consumerKey = "qyprdWTsI8u6Qq3fwiIUvkweM2mabZ";
            string consumerSecret = "9KH9mFlGy5CPSUQCOV2lM3lHGs05AK5TtdS0QLWv";
            OAuthRequestValidator oauthValidator = new OAuthRequestValidator(
            accessToken, accessTokenSecret, consumerKey, consumerSecret);
            string appToken = "5b1cb122b340db43d4bae6bb880c8a28449";
            string companyID = "32534654";
            ServiceContext context = new ServiceContext(appToken, companyID, IntuitServicesType.QBO, oauthValidator);
            DataService service = new DataService(context);
            Customer customer = new Customer
            {
                GivenName = "Mary",
                Title = "Ms.",
                MiddleName = "Jayne",
                FamilyName = "Cooper",
                Id = "1234214"
            };
            //Mandatory Fields
            customer.CCDetail.Number = "444747447474474";
            customer.CCDetail.CcExpiryMonth = 12;
            customer.CCDetail.CcExpiryYear = 2018;
            Customer resultCustomer = service.Add(customer) as Customer;
            }
