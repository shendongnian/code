    bool onlyTouched;
    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
    
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //Touched
                onlyTouched = true;
            }
    
    
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                //Moved Finger (Now Invalid!)
                onlyTouched = false;
            }
    
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                //Check if only touched then change color
                if (onlyTouched)
                {
                    Debug.Log("Only touched Finger");
                    //MeshRenderer mr = ourHitObject.GetComponentInChildren<MeshRenderer>();
                    //mr.material.color = color[Random.Range(0, color.Length)];
    
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform != null)
                        {
                            MeshRenderer mr = hit.transform.gameObject.GetComponentInChildren<MeshRenderer>();
                            mr.material.color = color[Random.Range(0, color.Length)];
    
    
                            //hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
                        }
                    }
                }
                else
                {
                    Debug.Log("Finger was moved while touching");
                }
    
                //Reset onlyTouched for next read
                onlyTouched = false;
            }
        }
    }
