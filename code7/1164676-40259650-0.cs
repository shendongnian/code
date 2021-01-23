    var client = new MagentoApi()
                       .SetCustomAdminUrlPart(AdminUrlPart)
                       .Initialize(StoreUrl, ConsumerKey, ConsumerSerect)
                       .AuthenticateAdmin(AdminUserName, AdminPassword);
    
                var filter = new Magento.RestApi.Models.Filter();
                //filter.FilterExpressions.Add(new FilterExpression("name", ExpressionOperator.like, "L%"));
                filter.PageSize = 100;
                filter.Page = 0;
                // var response = await client.GetProducts(filter);
                var sCode = Task.Run(async () => await client.GetProducts(filter));
                MagentoApiResponse<IList<Magento.RestApi.Models.Product>> product = sCode.Result;
