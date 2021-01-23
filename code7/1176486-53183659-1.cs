    [SerializeField]
    private float speed = 100;
    private bool playerDead;
    OnCollisionEnter(Collision collision)
    {
     
       if(collision.gameObject.tag == "Enemy")
       {
       
       playerDead = true;
       Vector3 direction = (transform.position - collision.transform.position).normalized;
       collision.GetComponent<Rigidbody>().AddForce (direction * speed,0,0);
       //AddForce is a vector3 apparently and requires (x,y,z)
       // Also note that I'm getting errors with the "collision.GetComponent<>"
      // You're going to want to remove "collision"
     // I think the smarter approach maybe to declare a public Rigidbody variable ( Up Top )
        [SerializeField]
        private Rigidbody playerRidg;
        playerRidg = GetComponent<Rigidbody>().AddForce(direction * speed,0,0);
       }
    }
