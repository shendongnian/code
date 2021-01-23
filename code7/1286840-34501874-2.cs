    public class HealthManager : MonoBehaviour {
    // Create the delegate
    public delegate void ObjectDeath(GameObject go);
    // Create the event
    public event ObjectDeath OnObjectDeath;
    //this method must not be marked static also 
    public void GiveDamage(GameObject dealer, GameObject receiver, float amount){
        /* 
            Subtract health here
            ... Code Snipped ...
        */
        if(objectHealth.health <= objectHealth.deathHealth){
            // Trigger the delegate/event
            OnObjectDeath();
        }
    }
