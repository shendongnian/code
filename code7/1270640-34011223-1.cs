    //EndCollider.cs
    public bool isShown
    {
        get { return PlayerPrefs.GetInt("IS_SHOWN")==1? true:false; }
        set { PlayerPrefs.SetInt("IS_SHOWN", Convert.ToInt32(value)); 
    }
    //SlowDownRun.cs
    if(PlayerPrefs.GetInt("IS_SHOWN")==1)  // isShown = true
    {
        ...
    }
 
 
