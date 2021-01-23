    public class DataAccess
    {
        private Context _cacheContext = new CachingFramework.Redis.Context("localhost:6379");
    
        private string FormatPostCodeKey(int postCodeId)
        {
            return string.Format("PostCode:{0}", postCodeId);
        }
        private string FormatPostCodeTag(int postCodeId)
        {
            return string.Format("Tag-PostCode:{0}", postCodeId);
        }
        private string FormatAddressKey(int customerAddressId)
        {
            return string.Format("Address:{0}", customerAddressId);
        }
    
        public void InsertPostCode(PostCode postCode)
        {
            Sql.InsertPostCode(postCode);
        }
        public void UpdatePostCode(PostCode postCode)
        {
            Sql.UpdatePostCode(postCode);
            //Invalidate cache: remove CustomerAddresses and PostCode related
            _cacheContext.Cache.InvalidateKeysByTag(FormatPostCodeTag(postCode.PostCodeId));
        }
        public void DeletePostCode(int postCodeId)
        {
            Sql.DeletePostCode(postCodeId);
            _cacheContext.Cache.InvalidateKeysByTag(FormatPostCodeTag(postCodeId));
        }
    
        public PostCode GetPostCode(int postCodeId)
        {
            // Get/Insert the postcode from/into Cache with key = PostCode{PostCodeId}. 
            // Mark the object with tag = Tag-PostCode:{PostCodeId}
            return _cacheContext.Cache.FetchObject(
                FormatPostCodeKey(postCodeId),              // Redis Key to use
                () => Sql.GetPostCode(postCodeId),          // Delegate to get the value from database
                new[] { FormatPostCodeTag(postCodeId) });   // Tags related
        }
        public void InsertCustomerAddress(CustomerAddress customerAddress)
        {
            Sql.InsertCustomerAddress(customerAddress);
        }
        public void UpdateCustomerAddress(CustomerAddress customerAddress)
        {
            var updated = Sql.UpdateCustomerAddress(customerAddress);
            if (updated.PostCodeId != customerAddress.PostCodeId)
            {
                var addressKey = FormatAddressKey(customerAddress.CustomerAddressId);
                _cacheContext.Cache.RenameTagForKey(addressKey, FormatPostCodeTag(customerAddress.PostCodeId), FormatPostCodeTag(updated.PostCodeId));
            }
        }
        public void DeleteCustomerAddress(CustomerAddress customerAddress)
        {
            Sql.DeleteCustomerAddress(customerAddress.CustomerAddressId);
            //Clean-up, remove the postcode tag from the CustomerAddress:
            _cacheContext.Cache.RemoveTagsFromKey(FormatAddressKey(customerAddress.CustomerAddressId), new [] { FormatPostCodeTag(customerAddress.PostCodeId) });
        }
        public CustomerAddress GetCustomerAddress(int customerAddressId)
        {
            // Get/Insert the address from/into Cache with key = Address:{CustomerAddressId}. 
            // Mark the object with tag = Tag-PostCode:{PostCodeId}
            return _cacheContext.Cache.FetchObject(
                FormatAddressKey(customerAddressId),
                () => Sql.GetCustomerAddress(customerAddressId),
                a => new[] { FormatPostCodeTag(a.PostCodeId) });
        }
    }
