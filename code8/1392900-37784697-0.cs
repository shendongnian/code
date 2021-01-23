            string culture = "en-US";
            var tree = new TreeProvider(MembershipContext.AuthenticatedUser);
            foreach (var shoppingCartItem in ECommerceContext.CurrentShoppingCart.CartItems)
            {
                // we need to get class name of item in shopping cart
                var productWithClassName = tree.SelectNodes()
                    .Where("NodeSKUID", QueryOperator.Equals, shoppingCartItem.SKUID)
                    .And()
                    .Where("DocumentCulture", QueryOperator.Equals, culture)
                    .Take(1)
                    .FirstOrDefault();
                if (productWithClassName != null)
                {
                    var product = tree.SelectSingleNode(productWithClassName.NodeID, culture);
                    if (product != null)
                    {                        
                        var customField = product.GetStringValue("CustomField", "-");
                    }
                }
            }
