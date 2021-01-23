    public void PostUpdate()
    {
        //stuff that always happens
        PhysicsUpdate();
    }
     public void Update()
    {
        UpdateMovement();
        if (IsIncapacitated)
            return PostUpdate();
        if (IsInventoryOpened)
        {
            UpdateInventory();
            return PostUpdate();
        }
    }
