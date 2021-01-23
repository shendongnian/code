    class PromotionTrackerService
    {
        private readonly Func<string, string> imageMapper;
        public PromotionTrackerService(Func<string, string> imageMapper)
        {
            this.imageMapper = imageMapper ?? HttpContext.Current.Server.MapPath;
        }
        public void GetProofOfPurchase()
        {
            var image = Image.GetInstance(imageMapper(GlobalConfig.HeaderLogo));
        }
    }
