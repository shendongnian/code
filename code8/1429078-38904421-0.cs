    public class OtherScript : MonoBehaviour
    {
        public GoogleAdsScript googleAds;
    
        void Start()
        {
            googleAds = GameObject.Find("AdsObj").GetComponent<GoogleAdsScript>();
            googleAds.RequestInterstitial();//Assumes that RequestInterstitial is now public
        }
    }
