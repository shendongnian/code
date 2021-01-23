    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // Register the action filter globally and provide a default number
            filters.Add(new ContactNumberActionFilter("0800 161 5191"));
            // TODO: Make filters for ContactNumberForPricingPage, 
            // ProductReference, and LegalReference and set their default
            // values here.
        }
    }
