    private bool canMove = true;
    public void SetMove(bool setCanMove) // called with animation events
    {
        canMove = setCanMove;
    }
    public void Move()
    {
        if (Input.GetAxisRaw("Horizontal") == 1 && canMove == true) //go right
        {
            //movement code and animation call...
        }
        // Other directions...
    }
