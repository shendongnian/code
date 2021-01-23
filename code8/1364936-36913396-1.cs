    public class Ads : MonoBehaviour
    {
    
        public string gameId;
        public string zoneId;
    
        public Button getAds;
    
        private Hearts heart;
    
        void OnEnable()
        {
            getAds.onClick.AddListener(() => GetAds(getAds));
        }
    
    
        private void GetAds(Button buttonPressed)
        {
            if (buttonPressed == getAds)
            {
                //Wait for ad to show. The timeout time is 3 seconds
                StartCoroutine(showAdsWithTimeOut(3));
            }
        }
    
        
        public void HandleShowResult(ShowResult result)
        {
            switch (result)
            {
                case ShowResult.Finished:
                    heart = GameObject.FindGameObjectWithTag("Hearts").GetComponent<Hearts>() as Hearts;
                    heart.AddHeart();
                    Debug.Log("<color=green>The ad was skipped before reaching the end.</color>");
                    break;
    
                case ShowResult.Skipped:
                    Debug.Log("<color=yellow>The ad was skipped before reaching the end.</color>");
                    break;
    
                case ShowResult.Failed:
                    Debug.LogError("<color=red>The ad failed to be shown.</color>");
                    break;
            }
        }
    
        IEnumerator showAdsWithTimeOut(float timeOut)
        {
            //Check if ad is supported on this platform 
            if (!Advertisement.isSupported)
            {
                Debug.LogError("<color=red>Ad is NOT supported</color>");
                yield break; //Exit coroutine function because ad is not supported
            }
    
            Debug.Log("<color=green>Ad is supported</color>");
    
            //Initialize ad if it has not been initialized
            if (!Advertisement.isInitialized)
            {
                //Initialize ad
                Advertisement.Initialize(gameId, true);
            }
        
    
            float counter = 0;
            bool adIsReady = false;
    
            // Wait for timeOut seconds until ad is ready
            while(counter<timeOut){
                counter += Time.deltaTime;
                if( Advertisement.IsReady (zoneId)){
                    adIsReady = true;
                    break; //Ad is //Ad is ready, Break while loop and continue program
                }
                yield return null;
            }
    
            //Check if ad is not ready after waiting
            if(!adIsReady){
                Debug.LogError("<color=red>Ad failed to be ready in " + timeOut + " seconds. Exited function</color>");
                yield break; //Exit coroutine function because ad is not ready
            }
    
            Debug.Log("<color=green>Ad is ready</color>");
    
            //Check if zoneID is empty or null
            if (string.IsNullOrEmpty(zoneId))
            {
                Debug.Log("<color=red>zoneId is null or empty. Exited function</color>");
                yield break; //Exit coroutine function because zoneId null
            }
    
            Debug.Log("<color=green>ZoneId is OK</color>");
            
            
            //Everything Looks fine. Finally show ad (Missing this part in your code)
            ShowOptions options = new ShowOptions();
            options.resultCallback = HandleShowResult;
    
            Advertisement.Show(zoneId, options);
        }
    
        void OnDisable()
        {
            getAds.onClick.RemoveAllListeners();
        }
    }
