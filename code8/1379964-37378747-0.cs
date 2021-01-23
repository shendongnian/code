    public AudioClip background_music;
    public AudioClip sandman_music;
    
    private AudioSource audioSource;
    
    Void Start()
    {
        audioSource = GetComponent<AudioSource>();
    
        //To play backround sound
        if (audioSource.isPlaying)
        {
                audioSource.Stop();
        }
        audioSource.clip = background_music;
        audioSource.Play();
    
        //To play sandman sound
        if (audioSource.isPlaying)
        {
        audioSource.Stop();
        }
        audioSource.clip = sandman_music;
        audioSource.Play();
    }
