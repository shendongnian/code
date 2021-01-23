    int health = 100;
    int lastFrameHealth;
    void Start ()
    {
        lastFrameHealth = health;
    }
    void Update ()
    {
        if (health < lastFrameHealth)
        {
            StartCoroutine("InterruptPassiveSkill", 5f);
        }
        lastFramehealth = health;
    }
    void OnCollisionEnter(Collision collision)
    {
        health -= 10;
    }
    IEnumerator InterruptPassiveSkill (float seconds)
    {
        // insert code to deactivate passive skill here:
        yield return new WaitForSeconds(seconds); // delay for number of seconds
        // insert code to reactivate passive skill here:
    }
