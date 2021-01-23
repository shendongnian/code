    float startTime;
    float endTime;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hitInfo;
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTime = Time.time;
            }
            //Debug.Log("Start time is: " + startTime);
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTime = Time.time;
                //Debug.Log("End time is: " + endTime);
                if (endTime - startTime < 0.150f)
                {
                    if (Physics.Raycast(ray, out hitInfo))
                    {
                        GameObject ourHitObject = hitInfo.collider.transform.parent.gameObject;
                        if (ourHitObject.GetComponent<Hex>() != null)
                        {
                            Touch_Hex(ourHitObject);
                        }
                        else if (ourHitObject.GetComponent<Unit>() != null)
                        {
                            Touch_Unit(ourHitObject);
                        }
                    }
                }
            }
        }
    }
