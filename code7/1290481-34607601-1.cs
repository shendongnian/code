    #define DUMMY_STORE
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.ApplicationModel.Store;
    
    namespace SO
    {
        public class LicenseManager
        {
            private readonly Dictionary<string, bool> _dummyLicense;
    
    #if DUMMY_STORE
            public LicenseManager()
            {
                // Init license for testing only
                _dummyLicense = new Dictionary<string, bool>
                {
                    {"hello", true}
                };
            }
    #endif
    
            public bool IsActive(string feature)
            {
    #if DUMMY_STORE
                return _dummyLicense[feature];
    #else
                return CurrentApp.LicenseInformation.ProductLicenses[feature].IsActive;
    #endif
            }
        }
    }
