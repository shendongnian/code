        private async Task RefreshInAppOffers()
        {
            // in-app offers
            List<KeyValuePair<string, ProductListing>> products = null;
            UnfulfilledConsumable unfulfilledConsumable = null;
            InAppOffers.Children.Clear();
            try
            {
                var listinginfo = await CurrentAppProxy.LoadListingInformationAsync();
                products = listinginfo.ProductListings.ToList();
                products.Sort((p1, p2) => p1.Value.FormattedPrice.CompareTo(p2.Value.FormattedPrice));
