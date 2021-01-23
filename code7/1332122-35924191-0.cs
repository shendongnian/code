    HashSet<WebListingVerification> listings = new HashSet<WebListingVerification>();
    string sku = reader["vsr_sku"].ToString();
    string vendorName = reader["v_name"].ToString();
    string vendorSku = reader["vsr_vendor_sku"].ToString();
    
    if(listings.Contains(listing))
    {
        listings.Remove(listing);
        listing.Vendor = vendorName;
        listing.VendorSKU = vendorSku;
        listings.Add(listing);
    }
