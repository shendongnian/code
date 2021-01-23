    private bool _IsAdminLoggedIn = false;
    if (umbraco.helper.GetCurrentUmbracoUser() != null)
    {
        _IsAdminLoggedIn = !string.IsNullOrEmpty(umbraco.helper.GetCurrentUmbracoUser().UserType.Alias) && umbraco.helper.GetCurrentUmbracoUser().UserType.Alias == "admin";
    }
