    float timer = 0f;
    float fiveMinutes = 300; //300 seconds = 5minutes
    void Update()
    {
     if (myProcess!= null)
     {
        //Check if Time has reached
        if(timer>fiveMinutes){
            myProcess.Kill();
            myProcess.Close();
            return;
        }
        timer += Time.deltaTime;
       if (!myProcess.HasExited)
       {
        //Do Your Animation Stuff Here
       }
     }
    }
