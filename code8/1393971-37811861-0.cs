        public void Update()
        {
            try
            {
                UpdateMovement();
                if (IsIncapacitated)
                    return;
                if (IsInventoryOpened)
                {
                    UpdateInventory();
                    return;
                }
                if (Input.HasAction(Actions.Fire))
                {
                    Fire();
                    return;
                }
                else if (Input.HasAction(Actions.Move))
                {
                    Move(Input.Axis);
                    return;
                }
            }
            finally
            {
                //this will run, no matter what the return value
            }
        }
