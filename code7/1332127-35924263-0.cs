    public class WebListingVerification
        {
            public string Sku { get; set; }
    
            public string VendorName { get; set; }
    
            public string VendorSku { get; set; }
        }
    
        public class ListingManager : IEnumerable <WebListingVerification>
        {
            private Dictionary<string, WebListingVerification> _webListDictionary;
    
            public ListingManager(IEnumerable <WebListingVerification> existingListings)
            {
                if (existingListings == null)
                    _webListDictionary = new Dictionary<string, WebListingVerification>();
                else
                    _webListDictionary = existingListings.ToDictionary(a => a.Sku);
            }
    
            public void AddOrUpdate (string sku, string vendorName, string vendorSku)
            {
                WebListingVerification verification;
                if (false == _webListDictionary.TryGetValue (sku, out verification))
                    _webListDictionary[sku] = verification = new WebListingVerification();
    
                verification.VendorName = vendorName;
                verification.VendorSku = vendorSku;
            }
    
            public IEnumerator<WebListingVerification> GetEnumerator()
            {
                foreach (var item in _webListDictionary)
                    yield return item.Value;
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();   
            }
        }
