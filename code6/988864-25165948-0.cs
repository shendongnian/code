    var CP = new GameOject ; // current selected
    var GCP = new GameOject ; // previous selected
    public static ObjectNames[] ={"current" , "previous"}; // change on select static to use these name elsewhere 
    string pName =""; // save the previous object name
    int x = 0; // track if only clicked once 
    
    
    if (Input.GetMouseButtonDown(0))
    		{
    		    
    			Ray Raycost = Camera.main.ScreenPointToRay(Input.mousePosition);
    			RaycastHit Hit;
    			if(Physics.Raycast(Raycost , out Hit , 230.0f , mask_ ))
    			{
    				
    				
    				
    				if(x != 0 && x < 2) // be sure selected at least 2 object
    				{
    					GCP =GameObject.Find(Pname); // on one click it is not working Pname is "" but when we came back ..;
    					ObjectNames[0] = Pname;
    				    GCP.renderer.material.color = Color.blue;
    					x = 0;
    				}
    				
    				x = 1 ;
    				
    				
    				
    				
    				GC = GameObject.Find(Hit.collider.gameObject.name); // current selected
    				GC.renderer.material.color = Color.red ;
    				
    				
    	
    				Pname = Hit.collider.gameObject.name; //pname = current it loop on next click
    				ObjectNames[1] = Hit.collider.gameObject.name;
    				
    			}
    			
    		}
