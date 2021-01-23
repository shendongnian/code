    #if UNITY_IPHONE
    using UnityEngine;
    using System.Collections;
    using System.Runtime.InteropServices;
     
    public class AD_AdsiOS
    {
    #if !UNITY_EDITOR
        [DllImport ("__Internal")]
        private static extern void _initAds(string p_adMobID);
        [DllImport ("__Internal")]
        private static extern void _showInterstitialAd();
        [DllImport ("__Internal")]
        private static extern void _showBannerAdTopRight();
        [DllImport ("__Internal")]
        private static extern void _hideBannerAds();
    #endif
     
        public AD_AdsiOS(string p_adMobID)
        {
    #if UNITY_EDITOR
            Debug.Log("AD_AdsiOS: will not work in editor.");
    #else
            _initAds(p_adMobID);
    #endif
        }
     
        public void ShowInterstitialAd()
        {
    #if UNITY_EDITOR
            Debug.Log("AD_AdsiOS: ShowInterstitialAd called in editor.");
    #else
            _showInterstitialAd();
    #endif
        }
     
        public void ShowBannerAdTopRight()
        {
    #if UNITY_EDITOR
            Debug.Log("AD_AdsiOS: ShowBannerAdTopRight called in editor.");
    #else
            _showBannerAdTopRight();
    #endif
        }
     
        public void HideBannerAds()
        {
    #if UNITY_EDITOR
            Debug.Log("AD_AdsiOS: HideBannerAds called in editor.");
    #else
            _hideBannerAds();
    #endif
        }
    }
    #endif
