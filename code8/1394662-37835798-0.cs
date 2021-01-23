    float tempZAxis;
    public SpriteRenderer selection;
    void Update()
    {
        Touch[] touch = Input.touches;
        for (int i = 0; i < touch.Length; i++)
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
            switch (touch[i].phase)
            {
                case TouchPhase.Began:
                    if (hit)
                    {
                        selection = hit.transform.gameObject.GetComponent<SpriteRenderer>();
                        if (selection != null)
                        {
                            tempZAxis = selection.transform.position.z;
                        }
                    }
                    break;
                case TouchPhase.Moved:
                    Vector3 tempVec = Camera.main.ScreenToWorldPoint(touch[i].position);
                    tempVec.z = tempZAxis; //Make sure that the z zxis never change
                    if (selection != null)
                    {
                        selection.transform.position = tempVec;
                    }
                    break;
                case TouchPhase.Ended:
                    selection = null;
                    break;
            }
        }
    }
