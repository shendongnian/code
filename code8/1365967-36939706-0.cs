    public class Bullet_explosive : MonoBehaviour {
    
    // Lifespan of the bullet
    float lifespan = 1.5f;
    
    // Setting up game objects
    public GameObject fireEffect;
    public GameObject explosion;
    public GameObject theGate;
    // Use this for initialization
    void Start () { }
    
    // Update is called once per frame
    void Update () 
    {   
        /* no "score" updating needed here in Update() */    
        lifespan -= Time.deltaTime;
    
        // Once the lifespan reaches 0, bullet is destroyed
        if (lifespan <= 0) 
        {
            Explode ();
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy") 
        {
            // Reduces the remaining enemies
            //Directly modify that one static field
            Scoring.enemiesRemaining -= 1;
    
            // Checks for no remaining enemies
            if (Scoring.enemiesRemaining <= 0) //here too
            {
                // Removes the gate
                Destroy(GameObject.FindWithTag ("Gate"));
            }
    
            // Changes the tag of the target hit
            collision.gameObject.tag = "Untagged";
    
            // Applies visual effects at the position and rotation of the target
            Instantiate (fireEffect, collision.transform.position, Quaternion.identity);
            Instantiate (explosion, collision.transform.position, Quaternion.identity);
    
            // Removes bullet and target
            Explode();
            Destroy (collision.gameObject);
        }
    }
    void Explode()
    {
        Destroy (gameObject);
    }
