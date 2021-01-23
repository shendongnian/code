    using UnityEngine;
    
    public class EMTChangeFile : MonoBehaviour
    {
    
    	// drag an instance of Media Player Ctrl or leave empty for autodetection
    	public MediaPlayerCtrl mediaPlayerCtrl;
    
    	void Awake ()
    	{
    		if (mediaPlayerCtrl == null)
    		{
    			mediaPlayerCtrl = FindObjectOfType<MediaPlayerCtrl>();
    			if (mediaPlayerCtrl == null)
    				throw new UnityException("No Media Player Ctrl object in scene");
    		}
    	}
    	
    	public void ChangeMovie(string movieName, bool autoplay = true)
    	{
    		mediaPlayerCtrl.Stop();
    		mediaPlayerCtrl.Load(movieName);
    		if(autoplay)
    			mediaPlayerCtrl.Play();
    		else
    			mediaPlayerCtrl.Stop();
    	}
    
    }
