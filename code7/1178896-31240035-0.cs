    public class ResxExtended : MyDBResources
        {
            private static IResourceProvider resourceProvider = new DbResourceProvider();
    
            public static string GetStringResx(string resourcekey)
            {
    
                return (string)resourceProvider.GetResource(resourcekey, CultureInfo.CurrentUICulture.Name);
    
            }
    
        }
