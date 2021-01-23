    public class Example: MonoBehaviour {
    	
    	public Image progress;
    	// Update is called once per frame
    	void Update () 
    	{
    			progress.fillAmount -=  Time.deltaTime;
    	}
    }
