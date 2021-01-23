    /// <summary>
        /// Wraps up XAML access to instance of WPFLocalize.Properties.Resources, list of available cultures, and method to change culture
        /// </summary>
        public class CultureResources
        {
            /// <summary>
            /// Backing filed for provider
            /// </summary>
            private static ObjectDataProvider provider;
    
            /// <summary>
            /// Gets Resource provider
            /// </summary>
            public static ObjectDataProvider ResourceProvider
            {
                get
                {
                    if (provider == null)
                    {
                        provider = (ObjectDataProvider)App.Current.FindResource("Resources");
                    }
    
                    return provider;
                }
            }
    
            /// <summary>
            /// Change the current culture used in the application.
            /// If the desired culture is available all localized elements are updated.
            /// </summary>
            /// <param name="culture">Culture to change to</param>
            public static void ChangeCulture(CultureInfo culture)
            {
                ////remain on the current culture if the desired culture cannot be found
                //// - otherwise it would revert to the default resources set, which may or may not be desired.
    
                V_Parcel.Properties.Resources.Culture = culture;
                ResourceProvider.Refresh();
            }
    
            /// <summary>
            /// The Resources ObjectDataProvider uses this method to get an instance of the WPFLocalize.Properties.Resources class
            /// </summary>
            /// <returns>Returns resource instance</returns>
            public V_Parcel.Properties.Resources GetResourceInstance()
            {
                return new V_Parcel.Properties.Resources();
            }
        }
