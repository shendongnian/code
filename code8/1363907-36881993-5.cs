    SpriteRenderer coinSpriteRenderer;
    AudioSource coinCollectSound;
    
    void Start()
    {
        coinCollectSound = gameObject.GetComponent<AudioSource>();
        coinSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    
    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.CompareTag("Bee"))
        {
    
            score.AddScore (point);
            StartCoroutine(fadeAndWaitForSound(1));
        }
    
        if (colisor.gameObject.CompareTag("floor"))
        {
            StartCoroutine(fadeAndWaitForSound(1));
        }
    
    }
    
    IEnumerator fadeAndWaitForSound(float fadeTimeInSeconds = 1)
    {
    
        Color currentColor = coinSpriteRenderer.color;
    
        Color invisibleColor = coinSpriteRenderer.color;
        invisibleColor.a = 0; //Set Alpha to 0
    
    
        float counter = 0;
    
        //Play sound
        coinCollectSound.Play();
    
        //Wait till sound is done playing
        while (coinCollectSound.isPlaying)
        {
            yield return null; 
        }
    
        //Now Fade texture
        while (counter < fadeTimeInSeconds)
        {
            counter += Time.deltaTime;
            coinSpriteRenderer.color = Color.Lerp(currentColor, invisibleColor, counter / fadeTimeInSeconds);
            yield return null;
        }
    
        //Destroy after fading
        Destroy(gameObject);
    }
