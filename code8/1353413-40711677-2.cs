    private void RequestRewardBasedVideo(){
       #if UNITY_EDITOR
           string adUnitId = "unused";
       #elif UNITY_ANDROID
           string adUnitId = "INSERT_AD_UNIT_HERE";
       #elif UNITY_IPHONE
           string adUnitId = "INSERT_AD_UNIT_HERE";
       #else
           string adUnitId = "unexpected_platform";
       #endif
       RewardBasedVideoAd rewardBasedVideo = RewardBasedVideoAd.Instance;
       AdRequest request = new AdRequest.Builder().Build();
       rewardBasedVideo.LoadAd(request, adUnitId);
    }
...
    // Reward based video instance is a singleton. Register handlers once to
    // avoid duplicate events.
    if (!rewardBasedEventHandlersSet){
       // Ad event fired when the rewarded video ad
       // has been received.
       rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
       // has failed to load.
       rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
       // is opened.
       rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
       // has started playing.
       rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
       // has rewarded the user.
       rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
       // is closed.
       rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
       // is leaving the application.
       rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
       rewardBasedEventHandlersSet = true;
    }
