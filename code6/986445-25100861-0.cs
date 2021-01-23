    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    public class ScoreManager : MonoBehaviour 
    {
    	public GUIText score;
    
    	private Stack<int> stack;
    
    	void Awake() 
    	{
    		stack = new Stack<int>();
    	}
    	
    
    	void Update() 
    	{
    		if(stack.Count > 0)
    			score.text = stack.Pop() + "";
    	}
    
    	public void addScore(int point)
    	{
    		stack.Push(point);
    	}
    }
