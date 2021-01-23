    void Start()
      {
      .. start playing your audio here ..
      Invoke("TwoMinutesHasPassed", 120f);
      }
     
    void TwoMinutesHasPassed()
      {
      Debug.Log("two minutes has passed");
      .. do anything you want here ..
      }
