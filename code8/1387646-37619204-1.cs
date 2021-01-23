    AudioSource myAudio;
    GameObject myBallObject;
    TouchObjectScript myTouchObjectScript;
    int oyunsonu = 0;
    
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        myBallObject = GameObject.FindWithTag("Ball");
        myTouchObjectScript = myBallObject.GetComponent<TouchObjectScript>();
        oyunsonu = PlayerPrefs.GetInt("oyunsonu");
    }
    
    void Update()
    {
        if (oyunsonu == 0)
        {
    
            // Code for OnMouseDown in the iPhone. Unquote to test.
            RaycastHit hit = new RaycastHit();
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
    
                    touchY = Input.GetTouch(i).position.y;
                    if (Physics.Raycast(ray, out hit))
                    {
                        //Debug.Log (hit.transform.gameObject.name.ToString ());
                        Instantiate(effect, myBallObject.transform.position, transform.rotation);
                        myAudio.PlayOneShot(saundFile[3], 1);
                        //TextAnimation.Show ();
                        myTouchObjectScript.BallForce(hit.transform.gameObject.tag.ToString(), touchY, screenHeight);
                    }
    
                }
            }
        }
    
    }
