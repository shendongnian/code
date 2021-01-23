    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            jumping = false;
    
            rigidBody.velocity = Vector3.zero;
        }        
    }
