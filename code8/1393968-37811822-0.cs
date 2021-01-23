    public void Update()
    {
        UpdateMovement();
        if (IsIncapacitated){
            return;
        }
        if (IsInventoryOpened)
        {
            UpdateInventory();
        }
        else if (Input.HasAction(Actions.Fire))
        {
            Fire();
        }
        else if (Input.HasAction(Actions.Move))
        {
            Move(Input.Axis);
        }
    }
