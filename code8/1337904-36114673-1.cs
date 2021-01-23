    float rot_duration = 10f;
    float rot_speed = 3f;
    float rot_elapsedTime = 3f;
    Quaternion final_rot;
    
    public void Update()
    {
        if (Input.GetMouseButtonUp(0)) 
        {
            StartCoroutine (Delay (1));
        }
        if (rot_elapsedTime < rot_duration) {
            cubeMesh.transform.rotation = Quaternion.Slerp (transform.rotation, final_rot, rot_elapsedTime);
            rot_elapsedTime += Time.deltaTime * rot_speed;
    }
    
    IEnumerator Delay(float waitTime)
    {
       yield return new WaitForSeconds (waitTime);
       rot_elapsedTime = 0.0F;
    }
