            try
            {
                var listing = await CurrentApp.LoadListingInformationAsync();
                var iap = listing.ProductListings.FirstOrDefault(p => p.Value.ProductId == "removeads");
                receipt = await CurrentApp.RequestProductPurchaseAsync(iap.Value.ProductId, true);
                if (CurrentApp.LicenseInformation.ProductLicenses[iap.Value.ProductId].IsActive)
                {
                    CurrentApp.ReportProductFulfillment(iap.Value.ProductId);
                    //your code after purchase is successful
                }
            }
            catch (Exception ex)
            {
                //exception 
            }
