    float timer = 0f;
    float fiveMinutes = 300; //300 seconds = 5minutes
    bool badExit = false;
    void Update()
    {
     if (myProcess != null)
     {
        //Check if Time has reached
        if(timer>fiveMinutes){
            myProcess.Kill();
            myProcess.Close();
            badExit = true;
            return;
        }
        timer += Time.deltaTime;
       if (!myProcess.HasExited)
       {
        //Do Your Animation Stuff Here
       }else{
          //Check if this was bad or good exit
          if(badExit){
            //Bad
           }else{
            //Good
            }
        }
     }
    }
