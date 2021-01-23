    public class UserProfile : ProfileBase
    {
        public static UserProfile GetUserProfile(string username)
        {
            return Create(username) as UserProfile;
        }
        public static UserProfile GetUserProfile()
        {
            return Create(Membership.GetUser().UserName) as UserProfile;
        }
        [SettingsAllowAnonymous(false)]
        public string CountryCode
        {
            get { return base["countryCode"] as string; }
            set { base["countryCode"] = value; }
        }
        [SettingsAllowAnonymous(false)]
        public string Description
        {
            get { return base["Description"] as string; }
            set { base["Description"] = value; }
        }
        [SettingsAllowAnonymous(false)]
        public string Location
        {
            get { return base["Location"] as string; }
            set { base["Location"] = value; }
        }
        [SettingsAllowAnonymous(false)]
        public string FavoriteMovie
        {
            get { return base["FavoriteMovie"] as string; }
            set { base["FavoriteMovie"] = value; }
        }
    }
