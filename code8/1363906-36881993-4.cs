    AudioSource[] coinCollectSound;
    
    void Start()
    {    
        coinCollectSound = new AudioSource[3];
        coinCollectSound[0] = GameObject.Find("COINSOUNDS/COINSOUND1").GetComponent<AudioSource>();
        coinCollectSound[1] = GameObject.Find("COINSOUNDS/COINSOUND2").GetComponent<AudioSource>();
        coinCollectSound[2] = GameObject.Find("COINSOUNDS/COINSOUND3").GetComponent<AudioSource>();
    }
    
    
    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.CompareTag("Bee"))
        {
    
            coinCollectSound[0].Play();//Play COINSOUND1
            coinCollectSound[1].Play();//Play COINSOUND2
            coinCollectSound[2].Play();//Play COINSOUND3
    
            score.AddScore (point);
            Destroy(gameObject);
        }
    
        if (colisor.gameObject.CompareTag("floor"))
        {
            Destroy(gameObject, 1.5f);
    
        }
    }
