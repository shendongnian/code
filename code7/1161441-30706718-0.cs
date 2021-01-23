    bool _isAnimating = false;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1))//If clicked
        {
            clickPosition(); //Gets the click position
    
            //start animation here!!!
            //animator.SetBool("bWalk", false);
    
            //and set animation state to true
            _isAnimating = true;
        }
    
        if (Vector3.Distance(transform.position, mouseClick) > minDistance)
        {
            clickToMove();
        }
        else if(_isAnimating)
        {
        	//turn off the animation here!!!
        	//animator.SetBool("bStop", false);
    
        	//and set to false
        	_isAnimating = false;
        }
    }
