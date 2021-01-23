    using GoogleMobileAds.Api;
            
    public static class AdManagerScript
    {
        private static InterstitialAd interstitial;
        // Call this method only once when your app starts
        public static void StartMobileAdsSDK()
        {
            #if UNITY_ANDROID
                string appId = "...your admob appid here...";
                MobileAds.Initialize(appId);
            #endif
        }
        public static void RequestInterstitial()
        {
            #if UNITY_ANDROID
                string adUnitId = "ca-app-pub-3940256099942544/1033173712";
                interstitial = new InterstitialAd(adUnitId);
                AdRequest request = new AdRequest.Builder().Build();
                interstitial.LoadAd(request);
            #endif
        }
    
        public static void ShowInterstitital()
        {
            #if UNITY_ANDROID
                if (interstitial.IsLoaded())
                {
                    interstitial.Show();
                }
            #endif
        }
