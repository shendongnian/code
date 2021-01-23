    GameObject player;
    void Start()
    {
        player = this.gameObject;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LoseCollider")
        {
            // Update the sprite
        }
    }
