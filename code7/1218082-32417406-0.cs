    using UnityEngine;
    using System.Collections;
    
    public class TouchSomething : MonoBehaviour 
    {
    	public GameObject thingToMove;
    	
    	private Vector3 _worldPosition;
    	
    	private void Update()
    	{
    		if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
    		{
    			_worldPosition = HandleTouchInput();
    		}
    		else
    		{
    			_worldPosition = HandleMouseInput();
    		}
    		
    		thingToMove.transform.position = new Vector3(_worldPosition.x, _worldPosition.y, 0);
    	}
    	
    	private Vector3 HandleTouchInput()
    	{
    		var newPosition = thingToMove.transform.position;
    		for (var i = 0; i < Input.touchCount; i++) 
    		{
    			if (Input.GetTouch(i).phase == TouchPhase.Began) 
    			{
    				var screenPosition = Input.GetTouch(i).position;
    				newPosition = Camera.main.ScreenToWorldPoint(screenPosition);
    				
    			}
    		}
    			
    		return newPosition;
    	}
    	
    	private Vector3 HandleMouseInput()
    	{
    		var newPosition = thingToMove.transform.position;
    		if(Input.GetMouseButtonDown(0))
    		{
    			var screenPosition = Input.mousePosition;
    			newPosition = Camera.main.ScreenToWorldPoint(screenPosition);
    		}
    		
    		return newPosition;
    	}
    }
