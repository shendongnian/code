    using Sitecore.Intranet.Profiles;
    using Sitecore.Intranet.Profiles.Providers;
    using Sitecore.Security.Accounts; 
    // ------------------------------
    var userName = User.Current.Name;
    var account = Account.FromName(userName, AccountType.User);
    var profileProvider = new UserProfileProvider(new Settings());
    var profile = profileProvider.GetProfile(account.LocalName.ToLower());
    var profileItem = profile.ProfileItem;
