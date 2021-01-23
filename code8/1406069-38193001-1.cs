    public bool IsGrounded()
    {
        grounded = grounded = playerCollider.IsTouchingLayers(groundLayer.value);
        return grounded;
    }
