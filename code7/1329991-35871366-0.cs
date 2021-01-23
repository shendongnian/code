        public static string GetLocalizedString(string text)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(typeof(LocalizationExtensions));
            cultureInfo = new CultureInfo(HttpContext.Current.Cache["Culture"].ToString());
            string clientName = HttpContext.Current.Cache["ClientName"].ToString();       
            return    (new System.Resources.ResourceManager("Resources." + clientName + "." + clientName, assembly)).GetString(text, cultureInfo) 
                   ?? (new System.Resources.ResourceManager("Resources.WordResources", assembly)).GetString(text, cultureInfo) 
                   ?? text;
        }
