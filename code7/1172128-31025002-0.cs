    public class GlobalisationCookie
    {
    
        public GlobalisationCookie(HttpRequestBase request, HttpResponseBase response)
        {
            _request = request;
            _response = response;
    
        }
    
        private readonly HttpRequestBase _request;
        private readonly HttpResponseBase _response;
    
        //
        // Gets a collection of users languages from the Accept-Language header in their request
        //
        private String[] UserLanguges
        {
            get
            {
                return _request.UserLanguages;
            }
    
        }
    
        //
        // A dictionary of cultures the application supports - We point this to a custom webconfig section
        //  This collection is in order of priority
        public readonly Dictionary<string, string> SupportedCultures = new Dictionary<string, string>() { { "en-GB", "English - British" }, { "no", "Norwegian"} }
    
        //
        //  Summary:
        //       reads the first part of the culture i.e "en", "es"
        //
        private string GetNeutralCulture(string name)
        {
            if (!name.Contains("-")) return name;
    
            return name.Split('-')[0];
        }
    
    
    
        //
        //  Summary:
        //      returns the validated culture code or default
        //
        private string ValidateCulture(string userCulture)
        {
    
            if (string.IsNullOrEmpty(userCulture))
            {
                //no culture found - return default
                return SupportedCultures.FirstOrDefault().Key;
            }
    
            if (SupportedCultures.Keys.Any(x => x.Equals(userCulture, StringComparison.InvariantCultureIgnoreCase)))
            {
                //culture is supported by the application!
                return userCulture;
            }
    
            //  find closest match based on the main language. for example
            //      if the user request en-GB return en-US as it is still an English language
            var mainLanguage = GetNeutralCulture(userCulture);
    
            foreach (var lang in SupportedCultures)
            {
                if (lang.Key.StartsWith(mainLanguage)) return lang.Key;
            }
    
            return SupportedCultures.FirstOrDefault().Key;
    
        }
    
    
        //
        // Called from the OnInitialise method. Sets the culture based on the users cookie or accepted language
        //
        public void CheckGlobalCookie()
        {
    
            string cultureCode;
    
            var cookie = _request.Cookies["Globalisation"];
    
            if (cookie != null)
            {
                cultureCode = cookie.Value;
            }
            else
            {
                cultureCode = UserLanguges != null ? UserLanguges[0] : null;
            }
    
            //
            // Check we support this culture in our application
            //
            var culture = ValidateCulture(cultureCode);
    
            //
            // Set the current threads culture
            //
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
    
        }
    
        //
        //  Summary
        //      Called when the user picks there own culture
        //
        public void SetGlobalisationCookie(string culture)
        {
    
            culture = ValidateCulture(culture);
    
            var cookie = _request.Cookies["Globalisation"];
    
            if (cookie != null)
            {
    
                cookie.Value = culture;
            }
            else
            {
    
                cookie = new HttpCookie("Globalisation")
                {
                    Value = culture,
                    Expires = DateTime.Now.AddYears(1)
                };
    
            }
    
            cookie.Domain = FormsAuthentication.CookieDomain;
            _response.Cookies.Add(cookie);
    
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
    
        }
    
    }
