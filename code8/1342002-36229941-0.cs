    float decreaseTime = 0.2f;
    float startCounter = 0f;
    public float loss_hp = 1;
    void OnTriggerStay2D(Collider2D other)
    {
        GameObject gObj = other.gameObject;
        if (gObj.CompareTag("enemy") && hajs.hp > 0)
        {
            //Dont decrease if  startCounter < decrease Time
            if (startCounter < decreaseTime)
            {
                startCounter += Time.deltaTime;
                return;
            }
            startCounter = 0; //Reset to 0
            hajs.hp = hajs.hp - loss_hp;
        }
    }
