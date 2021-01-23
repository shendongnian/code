    void OnCollisionEnter (Collision collision)
    {
        ContactPoint contactPoint = collision.contacts [0];
    
        GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
        cube.transform.position = contactPoint.point;
    }
