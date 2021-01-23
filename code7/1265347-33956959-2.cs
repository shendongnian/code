    void CreateGlue(Vector3 position, GameObject other) {
    	// Here we create a glue object programatically, but you can make a prefab if you want.
    	// Glue object is a simple transform with Glue.cs script attached.
    	var glue = (new GameObject("glue")).AddComponent<Glue>();
    
    	// We set glue position at the contact point
    	glue.transform.position = position;
    
    	// This also enables us to support object rotation. We initially set glue rotation to the same value
    	// as our game object rotation. If you don't want rotation - simply remove this.
    	glue.transform.rotation = transform.rotation;
    
    	// We make the object we collided with a parent of glue object
    	glue.transform.SetParent(other.transform);
    
    	// And now we call glue initialization
    	glue.AttachObject(gameObject);
    }
    
    void OnCollisionEnter(Collision col)
    {
    	// On collision we simply create a glue object at any contact point.
    	CreateGlue(col.contacts[0].point, col.gameObject);
    }
