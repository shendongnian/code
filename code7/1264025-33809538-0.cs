    SPSecurity.RunWithElevatedPrivileges(delegate() {
        using(SPSite siteCollection = new SPSite("http://****:****/VijaiTest/")) {
            SPWeb web = siteCollection.RootWeb;
            if(PublishingWeb.IsPublishingWeb(web)){
                PublishingWeb publishingWeb = PublishingWeb.GetPublishingWeb(web);
                // Don't show Subsites 
                publishingWeb.Navigation.GlobalIncludeSubSites = false;
                // Don't show Pages 
                publishingWeb.Navigation.GlobalIncludePages = false;
                // Maximum number of dynamic items to show within this level of navigation: 
                publishingWeb.Navigation.GlobalDynamicChildLimit = 60;
                publishingWeb.IncludeInCurrentNavigation = false;
                web.AllowUnsafeUpdates = true;
                //Update the changes
                publishingWeb.Update();
            }else{
                throw new Exception("Web is not a publishing web");
            }
        }
    });
