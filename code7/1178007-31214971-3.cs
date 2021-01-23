    using UnityEngine;
    using System.Collections;
    
    public class DNA : MonoBehaviour {
    
    	public bool[] chromosone;
    	public int boolLength = 36;
    	public int lifeTime;
    
    	public void init()
    	{
    		this.chromosone = new bool[boolLength];
    		for(int i = 0; i < boolLength; i++)
    		{
    			if(Random.Range (0,2) == 1)
    				this.chromosone[i] = true;
    			else
    				this.chromosone[i] = false;
    		}
    		lifeTime = Random.Range(1,3);
    	}
    }
