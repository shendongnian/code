    public class SlowDownRun : MonoBehaviour {
    
    public EndCollider MonsterShow;
    
    // Use this for initialization
    void Start ()
    {
        
    }
    
    void Update()
    {
        if (MonsterShow.isShow == true)
        {
            float movementSpeed = 10f;
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
    }
    
    }
