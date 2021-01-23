    ItemType itemType = new ItemType();   // = class eBay.Service.Core.Soap.ItemType
    Int32 condCodeAsInt = 1000; // upto you to derrive this from your use case.
    String myBrandValue = "Some BRAND";
    String myMpnValue = "some MPN"; 
    String myUpcValue = "Does not apply";
....
    //if condition is "New" or "New with Details" then we need to set extra REQUIRED fields
                if (condCodeAsInt == 1000 || condCodeAsInt == 1500)
                {
                    //if it is "new" then remove inputted desc text completely REQUIRED
                    if (condCodeAsInt == 1000)
                    {
                        itemType.ConditionDescription = "";
                    }
     
                    // set UPC value HERE, not in ItemSpecifics. 
                    ProductListingDetailsType pldt =  new ProductListingDetailsType();
                    pldt.UPC = myUpcValue;
     
                    itemType.ProductListingDetails = pldt;
     
                    //init Item specifics ( and set BRAND and MPN )
                    itemType.ItemSpecifics = new NameValueListTypeCollection();
     
                    //brand
                    NameValueListType nvBrand = new NameValueListType();
                    nvBrand.Name = "Brand";
                    StringCollection brandStringCol = new StringCollection();
                    brandStringCol.Add(myBrandValue);
                    nvBrand.Value = brandStringCol;
     
                    itemType.ItemSpecifics.Add(nvBrand);
     
                    //MPN
                    NameValueListType nvMpn = new NameValueListType();
                    nvMpn.Name = "MPN";
                    StringCollection mpnStringCol = new StringCollection();
                    mpnStringCol.Add(myMpnValue);
                    nvMpn.Value = mpnStringCol;
     
                    itemType.ItemSpecifics.Add(nvMpn);
     
                }
