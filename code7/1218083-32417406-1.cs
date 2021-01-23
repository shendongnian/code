    using UnityEngine;
    using System.Collections;
    
    public class TouchSomething : MonoBehaviour 
    {
    	public GameObject thingToMove;
    	
    	public float smooth = 2;
    	
    	private Vector3 _endPosition;
    	
    	private Vector3 _startPosition;
    	
    	private void Awake()
    	{
    		_startPosition = thingToMove.transform.position;
    	}
    	
    	private void Update()
    	{
    		if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
    		{
    			_endPosition = HandleTouchInput();
    		}
    		else
    		{
    			_endPosition = HandleMouseInput();
    		}
    		
    		thingToMove.transform.position = Vector3.Lerp(thingToMove.transform.position, new Vector3(_endPosition.x, _endPosition.y, 0), Time.deltaTime * smooth);
    	}
    	
    	private Vector3 HandleTouchInput()
    	{
    		for (var i = 0; i < Input.touchCount; i++) 
    		{
    			if (Input.GetTouch(i).phase == TouchPhase.Began) 
    			{
    				var screenPosition = Input.GetTouch(i).position;
    				_startPosition = Camera.main.ScreenToWorldPoint(screenPosition);
    			}
    		}
    			
    		return _startPosition;
    	}
    	
    	private Vector3 HandleMouseInput()
    	{
    		var newPosition = thingToMove.transform.position;
    		if(Input.GetMouseButtonDown(0))
    		{
    			var screenPosition = Input.mousePosition;
    			_startPosition = Camera.main.ScreenToWorldPoint(screenPosition);
    		}
    		
    		return _startPosition;
    	}
    }
