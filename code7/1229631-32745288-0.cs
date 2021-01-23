    // e.g. in ShieldMovement
    void OnCollisionEnter2D (Collision2D other) 
    {
        if (other.collider.tag != "Ship") {
            canMove = false;
        }
    }
