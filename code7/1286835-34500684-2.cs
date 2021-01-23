    public static void GiveDamage(GameObject dealer, GameObject receiver, float amount){
       /* 
           Subtract health here
           ... Code Snipped ...
       */
       if(objectHealth.health <= objectHealth.deathHealth){
           // Trigger the delegate/event
           receiver.GetComponent< DeathListener >().Died(); // no need for parameter
        }
    }
