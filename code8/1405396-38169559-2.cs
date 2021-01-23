    using UnityEngine;
    using System.Collections;
    
    public class GameController : MonoBehaviour {
    
    	public static GameController instance;
    
    	[System.NonSerialized] public int[] star = new int[64];
    
    	private void Awake()
    	{
    		if(instance == null)
    			instance = this;
    		else if(instance != this)
    			Destroy(gameObject);
    
    		DontDestroyOnLoad(gameObject);
    	}
    
    	private void Start()
    	{
    		StartCoroutine(SetAllTo(1));
    	}
    
        // for simulating some changes during the game
    	private IEnumerator SetAllTo(int value)
    	{
    		yield return new WaitForSeconds(2.0f);
    
    		for(int i = 0; i < star.Length; i++)
    			star[i] = value;
    
    		Debug.Log("Setting done");
    	}
    
    	public void PrintFirst()
    	{
    		Debug.Log(star[0]);
    	}
    }
