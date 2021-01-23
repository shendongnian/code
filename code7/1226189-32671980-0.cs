    void Start()
	{
		_startLocation = transform.position; // Changed Here to Initialize once  
	}
        void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {         
			Debug.Log("Left mouse button clicked");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Ground"))
                {	
					print(hit.point);
					//**Here you mentioned _StartLocation = transform.position
					//this instantly changes the starting point Every time so
					//if SP changes then totally changed in Translation.*** 
                    _endLocation= hit.point;
                    _isMoving = true;
                    _startTime = Time.time;
                    _distanceToTravel = Vector3.Distance(_startLocation, _endLocation);
                }
            }
        }
		if (_isMoving)
		{
			 Move();
		}
    }
    void Move()
    {
        float timeElapsed = (Time.time - _startTime) * Speed;
        float t = timeElapsed / _distanceToTravel;
        _currentLocation = Vector3.Lerp(_startLocation, _endLocation, t);
		transform.position = Vector3.Lerp(_startLocation, _endLocation, t);
		_startLocation = _endLocation;
					 //*** This line is for Next Mouse
					 //click. So every next click StartPoint is Current Click
					//EndPoint***
        if (_currentLocation == _endLocation)
        {
            Debug.Log(string.Format("Destination reached ({0})", _endLocation.ToString()));
            _isMoving = false;
        }
    }
    }
