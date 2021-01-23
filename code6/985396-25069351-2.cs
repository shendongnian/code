    private float lerpValue = 0;
    public float speed;
    private Vector3 startPosition;
    
    void Update () 
    {
        if (Input.GetMouseButtonUp (1))
    	{
            if (Hand.transform.childCount == 1)
    		{
    			lerpValue = 0;
    			startPosition = projectile.transform.position;
    		
                projectile.gameObject.transform.parent = null;
    
                Ray ray = new Ray(spawn.position,spawn.up);
                RaycastHit hit;
    
                float shotDistance = shotdistance;
    
                if (Physics.Raycast(ray,out hit, shotDistance))
    			{
                    shotDistance = hit.distance;
                    //speed = distance / time
    			    //therefore: time = distance / speed
    			    float time = shotDistance / speed;
    			
    			    StopAllCoroutines();
    		    	StartCoroutine(ProjectileMotion(hit.point, time));
                }
            }
        }
    }
    
    IEnumerator ProjectileMotion(Vector3 endPosition, float time)
    {
    	while(lerpValue < time)
    	{
    		lerpValue += Time.deltaTime;
    		projectile.transform.position = Vector3.Lerp(startPosition, endPosition, lerpValue / time);
    	}
    }
