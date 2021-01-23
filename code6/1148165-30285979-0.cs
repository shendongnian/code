    using UnityEngine;
    using System.Collections;
    using GoogleMobileAds.Api;
    
    public class Banner : MonoBehaviour {
    	private BannerView bannerView;
    	
        void Start() {
            bannerView = new BannerView ("************", AdSize.Banner, AdPosition.Top);
            AdRequest request = new AdRequest.Builder().Build ();
            bannerView.LoadAd(request);
            bannerView.Show();
        }
    	
    	void OnDestroy() {
    		bannerView.Destroy();
    	}
    }
