        public sealed class CurrentPrincipalFacade : IPrincipal
    {
        #region Singleton mechanism
        private static readonly CurrentPrincipalFacade instance = new CurrentPrincipalFacade();
        public static CurrentPrincipalFacade Instance { get { return instance; } }
        private CurrentPrincipalFacade() { }
        #endregion
        #region IPrincipal members
        public IPrincipal Principal { get; set; }
        public IIdentity Identity { get { return Principal == null ? null : Principal.Identity; } }
        public bool IsInRole(string role) { return Principal != null && Principal.IsInRole(role); }
        public void Reset() { Principal = new GenericPrincipal(new GenericIdentity(""), new string[] { }); }
        #endregion}
