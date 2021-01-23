        private void RecalculateTargetFloor()
        {
            if (targetFloor > currentFloor)
            {
                //going up
                GetNextUpperFloor();
                return;
            }
            else if (targetFloor < currentFloor)
            {
                //going down
                GetNextLowerFloor();
                return;
            }
            // Elevator reached target              
            inputs.RemoveAll(x => x == targetFloor);
                        if (IsGoingUp)
            {
                // if elevator is going up and there are some floors to go - go futher
                // otherwise go down. 
                if (inputs.Any(x => x > currentFloor))
                {
                    GetNextUpperFloor();
                    return;
                }
                else
                {
                    // no more floors to go up
                    IsGoingUp = false;
                    GetNextLowerFloor();
                    return;
                }
            }
            if (!IsGoingUp)
            {
                if (inputs.Any(x => x < currentFloor))
                {
                    GetNextLowerFloor();
                    return;
                }
                else
                {
                    // no more floors to go down
                    IsGoingUp = false;
                    GetNextUpperFloor();
                    return;
                }
            }
        }
