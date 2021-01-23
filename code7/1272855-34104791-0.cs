     public async System.Threading.Tasks.Task InAppInit()
        {
            try
            {
                var listing = await CurrentApp.LoadListingInformationAsync();
                if (listing.ProductListings.ContainsKey("deluxe"))
                {
                    // Delux Unlock - Durable
                    var unlockFeatureDelux = listing.ProductListings.FirstOrDefault(p => p.Value.ProductId == "deluxe" && p.Value.ProductType == ProductType.Durable);
                    isDeluxPurchased = CurrentApp.LicenseInformation.ProductLicenses[unlockFeatureDelux.Value.ProductId].IsActive;
                    deluxProductID = unlockFeatureDelux.Value.ProductId;
                }
                else
                {
                    //There is no deluxe IAP defined... so something with your IAP stuff is wrong...
                }
    
                if (listing.ProductListings.ContainsKey("standard"))
                {
                    // Standard Unlock - Durable
                    var unlockFeatureStandard = listing.ProductListings.FirstOrDefault(p => p.Value.ProductId == "standard" && p.Value.ProductType == ProductType.Durable);
                    isStarndardPurchased = CurrentApp.LicenseInformation.ProductLicenses[unlockFeatureStandard.Value.ProductId].IsActive;
                    standardProductID = unlockFeatureStandard.Value.ProductId;
                }
                else
                {
                    //same as for Delux
                }
            }
            catch
            {
                //Show  this on the UI...
            }
        }
