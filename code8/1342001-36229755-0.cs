     float timer = 0;
     bool timerCheck = false;
     float timerThreshold = 1000; // value you want to wait
     
     void Update()
     {
         if(timerCheck)
         {
            timer += Time.deltaTime;
         }
         if (timer > timerThreshold)
         {
            timer = 0;
            GameObject gObj = ...; // get player game object using GameObject.FindWithTag for example
            if (gObj.CompareTag("enemy") && hajs.hp > 0)
            {
                hajs.hp = hajs.hp - loss_hp;
            }
         }
     }
     
     void OnCollisionEnter2D(Collider2D col)
     {
        timerCheck = true;
     }
     
     void OnCollisionExit2D(Collider2D col)
     {
        timerCheck = false;
     }
