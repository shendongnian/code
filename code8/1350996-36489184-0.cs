    // What are these? They should be in some method
    void DestroyAll()
    {
        // Kills the game object
        Destroy(gameObject);
    
        // Removes this script instance from the game object
        //Destroy(this);
    
        // Removes the rigidbody from the game object
        Destroy(rigidbody);
    
        // Kills the game object in 5 seconds after loading the object
        Destroy(5, gameObject);
    }
    
    // When the user presses Ctrl, it will remove the script 
    // named FooScript from the game object
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Destroy(GetComponent<FooScript>());
        }
    }
