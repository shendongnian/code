    public class thingBumps : MonoBehaviour {
    
    public float thrust = 10; // give some default value 
    Rigidbody rb;// you dont need it to be public
    float nextKick = 0;
    float kickTimer = 0;
    public float MinKickTime=1, MaxKickTime=10;//seconds
    
    void Start() {
        rb = GetComponent<Rigidbody>();
        nextKick = Random.Range(MinKickTime,MaxKickTime);
    }
    
    void FixedUpdate()
    {
        kickTimer+=Time.fixedDeltaTime;
        if(kickTimer>nextKick)
        {
             rb.AddForce (transform.up * thrust, ForceMode.Impulse);
             kickTimer=0;
             nextKick = Random.Range(MinKickTime,MaxKickTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
            rb.AddForce(-transform.up * thrust,ForceMode.Impulse);
    }
    
    }
