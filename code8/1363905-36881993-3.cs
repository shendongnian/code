    AudioSource coinCollectSound;
    void Start()
    {
        coinCollectSound = GameObject.Find("Bee").GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D colisor)
        {
            if (colisor.gameObject.CompareTag ("Bee"))
            {
    
                coinCollectSound.Play();
    
                score.AddScore (point);
                Destroy(gameObject);
            }
    
            if (colisor.gameObject.CompareTag("floor"))
            {
                Destroy(gameObject, 1.5f);
    
            }
    }
