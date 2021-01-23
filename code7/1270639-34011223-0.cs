    //EndCollider.cs
    public bool isShow
    {
        get { return PlayerPrefs.GetInt("XYZ_IS_SHOWN")==1?true:false; }
        set { PlayerPrefs.SetInt("XYZ_IS_SHOWN", Convert.ToInt32(value)); 
    }
    //SlowDownRun.cs
    if(PlayerPrefs.GetInt("XYZ_IS_SHOWN")==1)  // isShow = true
    {
        ...
    }
 
 
