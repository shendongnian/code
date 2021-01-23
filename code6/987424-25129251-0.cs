    void Update(){
        if (platformMove == true) {
            PositionChanging ();
        }
    
    }
    
    void PositionChanging(){
    	StartCoroutine(WaitToMove());
        Vector2 positionA = new Vector2 (platformHolder.transform.position.x, platformHolder.transform.position.y - 4);
    
        newPosition = positionA;        
    
        platformHolder.transform.position = Vector2.Lerp(platformHolder.transform.position, newPosition, Time.deltaTime * smooth);
    }
    
    void OnCollisionEnter2D(Collision2D coll)
        {
            foreach(ContactPoint2D contact in coll.contacts)
            {   
                platformMove = true;
                currentPlatformPosition = (coll.transform.position.y);
            }
        }
        IEnumerator WaitToMove(){
            yield return new WaitForSeconds(0.5f);
            platformMove = false;
        }
