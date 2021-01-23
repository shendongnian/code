    void OnCollisionEnter (Collision collision)
    {
    if(!detectedCollision){
        ContactPoint contactPoint = collision.contacts [0];
    
        GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
        cube.transform.position = contactPoint.point;
    detectedCollision = true;
    } 
    }
