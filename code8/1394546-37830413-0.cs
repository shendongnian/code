    public class TransferServiceInformation
    {
        public int ProviderId { get; set; }
    
        private string prePurchaseOverride;
        public string PrePurchaseOverride
        {
            get
            {
                if(!PrePurchaseOverrideEnabled)
                {
                    // Get instances from the other class where providerID matches
                    var instance = TransferServiceProviderInformation.Instances.Where(i => i.ProviderId == this.ProviderId).FirstOrDefault();
                    if(instance != null)
                    return (instance).PrePurchaseInfo;
                }
                return null; // If no match found
            }
            set
            {
                prePurchaseOverride = value;
            }
        }
    
        private bool prePurchaseOverrideEnabled;
        public bool PrePurchaseOverrideEnabled { get; set; }
    }
    
    public class TransferServiceProviderInformation
    {
        // Store your instances static
        public static List<TransferServiceProviderInformation> Instances { get; set; }
    
        public TransferServiceProviderInformation()
        {
            // Add every new instance to the list
            Instances.Add(this);
        }
    
        public int ProviderId { get; set; }
        public string PrePurchaseInfo { get; set; }
    }
