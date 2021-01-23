    [Guid("c375fa80-150f-11d6-a618-0010a401eb10")]
    [ContractID(CookieServiceFactory.ContractID)]
    public class CookieServiceFactory : GenericOneClassNsFactory<CookieServiceFactory, CookieService>
    {
        public const string ContractID = "@mozilla.org/cookieService;1";
    }
    public class CookieService : nsICookieManager2
    {
        private static nsICookieManager2 _cookieService;
        static CookieService()
        {
            _cookieService = Xpcom.GetService<nsICookieManager2>(Contracts.CookieManager);
        }
