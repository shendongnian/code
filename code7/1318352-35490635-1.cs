    namespace WMShopify
    {
        // Is it common to have the namespace and class the same?
        //No, namespace should probably be the name of the project itself.
        public class WMShopify
        //this looks like a configuration class
        {
            // Are there different practices for private/public vars?
            public string APIKey { get; set; } // Capital
            public string password { get; set; } // lower case
            public string secretString { get; set; } // Camel
            private string _combinedVar; // Camel/underscore for private
        }
    
        // Should these be in a separate *.cs file?
        // I like to separate them because what happens when you have 100 classes, you just scroll forever?
        public class WMShopifyOrders
        {
            // Method capital/lower/camel?
            // I prefer capital
            public int getOrderCount()
            {
                // lower/capital/camel? Sure
                int localMemberVar = 0;
    
                return localMemberVar;
            }
        }
    
        // Should these be in a separate *.cs file? Yup
        public class WMShopifyProducts
        {
            public List<string> getProductList()
            {
                return new List<string>();
            }
        }
    }
