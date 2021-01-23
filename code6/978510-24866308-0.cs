    using UnityEngine;
    
    public class TimeStatistics : MonoBehaviour
    {	
    	public float TotalTime
    	{
    		get
    		{
    			float totalTime = Time.realtimeSinceStartup;
    			if(PlayerPrefs.HasKey("totaltime"))
    				totalTime += PlayerPrefs.GetFloat("totaltime");
    			return totalTime;
    		}
    
    	}
    
    	void OnApplicationQuit()
    	{
    		PlayerPregs.SetFloat("totaltime", this.TotalTime);
    	}
    }
