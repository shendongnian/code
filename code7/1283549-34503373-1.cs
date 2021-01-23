    public static class CurrentAppProxy
    {
        static bool? testmode = null;
        public static async void SetTestMode(bool mode)
        {
            testmode = mode;
            if (mode)
            {
                var file = await Package.Current.InstalledLocation.GetFileAsync("WindowsStoreProxy.xml");
                if (file != null)
                {
                    await CurrentAppSimulator.ReloadSimulatorAsync(file);
                }
            }
        }
        public static LicenseInformation LicenseInformation
        {
            get
            {
                if (testmode == null) throw new NotSupportedException();
                else if (testmode.Value) return CurrentAppSimulator.LicenseInformation;
                else return CurrentApp.LicenseInformation;
            }
        }
        public static IAsyncOperation<IReadOnlyList<UnfulfilledConsumable>> GetUnfulfilledConsumablesAsync()
        {
            if (testmode == null) throw new NotSupportedException();
            else if (testmode.Value) return CurrentAppSimulator.GetUnfulfilledConsumablesAsync();
            else return CurrentApp.GetUnfulfilledConsumablesAsync();
        }
        public static IAsyncOperation<ListingInformation> LoadListingInformationAsync()
        {
            if (testmode == null) throw new NotSupportedException();
            else if (testmode.Value) return CurrentAppSimulator.LoadListingInformationAsync();
            else return CurrentApp.LoadListingInformationAsync();
        }
        public static IAsyncOperation<FulfillmentResult> ReportConsumableFulfillmentAsync(string productId, Guid transactionId)
        {
            if (testmode == null) throw new NotSupportedException();
            else if (testmode.Value) return CurrentAppSimulator.ReportConsumableFulfillmentAsync(productId, transactionId);
            else return CurrentApp.ReportConsumableFulfillmentAsync(productId, transactionId);
        }
        public static IAsyncOperation<PurchaseResults> RequestProductPurchaseAsync(string productId)
        {
            if (testmode == null) throw new NotSupportedException();
            else if (testmode.Value) return CurrentAppSimulator.RequestProductPurchaseAsync(productId);
            else return CurrentApp.RequestProductPurchaseAsync(productId);
        }
    }
