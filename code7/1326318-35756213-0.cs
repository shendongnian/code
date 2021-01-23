    private float time = 0;
    
    public float fireTime = 1.1f;
    
    private void Update()
    {
      time += Time.deltaTime;
      
      if(Input.GetKeyDown("space") && time >= fireTime)
      {
        Vector3 shootPosition = transform.position + new Vector3 (0, 0.5f, 0);
        Instantiate (bullet, shootPosition, Quaternion.identity);
        time = 0;
      }
    }
