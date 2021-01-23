        void FixedUpdate() {
                if (Input.GetMouseButton(0))
                {
                    targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    if (rigidBody.position != targetPoint)
                    {
                        reachedTargetPoint = false;
                        if (reachedTargetPoint == false)
                        {
                            GetComponent<Rigidbody>().AddForce(speed);
                        }
                    }
                    //zoneBeforeReachingTP should be how much units before reaching targetPoint you want to start to decrease your rigidbody velocity
                    if (rigidBody.position == (targetPoint - zoneBeforeReachingTP))
                    {
    //speedReductionRate should be how much of speed you want to take off your rigidBody at the FixedUpdate time rate
                        rigidBody.velocity = speedReductionRate;
                    }
                    if(rigidBody.position == targetPoint)
                    {
                        rigidBody.velocity = new Vector3(0, 0, 0);
                        reachedTargetPoint = true;
                    }
                    ChangeRotationTarget();
                }
              
            }
