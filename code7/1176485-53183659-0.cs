    [SerializeField]
    private float speed = 100;
    private bool playerDead;
    OnCollisionEnter(Collision collision)
    {
     
       if(collision.gameObject.tag == "Enemy")
       {
       
       playerDead = true;
       Vector3 direction = (transform.position - collision.transform.position).normalized;
       collision.GetComponent<Rigidbody>().AddForce (direction * speed);
       }
    }
