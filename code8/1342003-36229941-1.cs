    float decreaseTime = 0.2f;
    float startCounter = 0f;
    public float loss_hp = 1;
    void OnTriggerStay2D(Collider2D other)
    {
        //Dont decrease if  startCounter < decrease Time
        if (startCounter < decreaseTime)
        {
         startCounter += Time.deltaTime;
         return;
        }
        startCounter = 0; //Reset to 0
         //Don't decrease if score is less or equals to 0
        if (hajs.hp <=0)
        {
           return;
        }
        GameObject gObj = other.gameObject;
        if (gObj.CompareTag("enemy"))
        {
          
            hajs.hp = hajs.hp - loss_hp;
        }
    }
