    void OnTriggerEnter ( Collider collidedAGV )
    {
        if (collidedAGV.tag == "cib" && collidedAGV.name == "collided object name")
        {
            //Do stuff
        }
    }
