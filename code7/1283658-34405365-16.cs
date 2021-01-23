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
                // if there is no any floors to go up - go down
                if (!inputs.Any(x => x > currentFloor))
                {
                    IsGoingUp = false;
                }
                else
                {
                    // or continue journey 
                    GetNextUpperFloor();
                }
            }
            else
            {
                if (!inputs.Any(x => x < currentFloor))
                {
                    IsGoingUp = true;
                }
                else { GetNextLowerFloor(); }
            }
        }
