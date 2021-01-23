    /// <summary>
    /// Sample e-commerce module class. Partial class ensures correct registration.
    /// </summary>
    [SampleECommerceModuleLoader]
    public partial class CMSModuleLoader
    {
        #region "Macro methods loader attribute"
        /// <summary>
        /// Module registration
        /// </summary>
        private class SampleECommerceModuleLoaderAttribute : CMSLoaderAttribute
        {
            /// <summary>
            /// Constructor
            /// </summary>
            public SampleECommerceModuleLoaderAttribute()
            {
                // Require E-commerce module to load properly
                RequiredModules = new string[] { ModuleEntry.ECOMMERCE };
            }
            /// <summary>
            /// Initializes the module
            /// </summary>
            public override void Init()
            {
                TaxClassInfoProvider.ProviderObject = new CustomTaxClassInfoProvider();
            }
        }
        #endregion
    }
