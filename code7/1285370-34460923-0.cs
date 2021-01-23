    void CreateWallsColliders ()
    		{
    			GameObject colliders = new GameObject ("Colliders");
    			colliders.transform.position = Vector3.zero;
    
    			GameObject leftCollider = new GameObject ("LeftCollider");
    			leftCollider.transform.position = Vector3.zero;
    			BoxCollider2D bcLeftCollider = leftCollider.AddComponent<BoxCollider2D> ();
    			leftCollider.transform.parent = colliders.transform;
    
    			GameObject rightCollider = new GameObject ("RightCollider");
    			rightCollider.transform.position = Vector3.zero;
    			BoxCollider2D bcRightCollider = rightCollider.AddComponent<BoxCollider2D> ();
    			rightCollider.transform.parent = colliders.transform;
    
    			GameObject topCollider = new GameObject ("TopCollider");
    			topCollider.transform.position = Vector3.zero;
    			BoxCollider2D bcTopCollider = topCollider.AddComponent<BoxCollider2D> ();
    			topCollider.transform.parent = colliders.transform;
    
    			GameObject bottomCollider = new GameObject ("BottomCollider");
    			bottomCollider.transform.position = Vector3.zero;
    			BoxCollider2D bcBottomCollider = bottomCollider.AddComponent<BoxCollider2D> ();
    			bottomCollider.transform.parent = colliders.transform;
    
    			// Assuming 15 x 15 tiles. Make it dynamic if you need.
    			// Assuming -1 and 15 are the limits on both sides
    
    			int rows = 15;
    			int cols = 15;
    
    			int lowerLimit = -1;
    			int upperLimit = 15;
    
    			leftCollider.transform.position = new Vector3 (lowerLimit, rows / 2);
    			leftCollider.transform.localScale = new Vector3 (1, cols, 1);
    
    			rightCollider.transform.position = new Vector3 (upperLimit, rows / 2);
    			rightCollider.transform.localScale = new Vector3 (1, cols, 1);
    
    			topCollider.transform.position = new Vector3 (cols / 2, upperLimit);
    			topCollider.transform.localScale = new Vector3 (rows, 1, 1);
    
    			bottomCollider.transform.position = new Vector3 (cols / 2, lowerLimit);
    			bottomCollider.transform.localScale = new Vector3 (rows, 1, 1);
    		}
