    public GameObject monster;
    public AudioSource aud;
    public AudioClip piano;
    void Start()
    {
        monster.SetActive(false);
        aud = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (aud.isPlaying)
        {
            return; //Exit if Audio is already playing
        }
        if (other.CompareTag("Player"))
        {
            monster.SetActive(true);
            aud.PlayOneShot(piano);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            monster.SetActive(false);
        }
        StartCoroutine(waitForAudioThenDestroy());
    }
    IEnumerator waitForAudioThenDestroy()
    {
        //Wait until we are done playing
        while (aud.isPlaying)
        {
            yield return null;//Don't freeze
        }
        //We are no longer playing audio so we can destroy this gameObject now
        Destroy(this.gameObject);
    }
