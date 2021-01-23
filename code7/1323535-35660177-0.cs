    float wait = 1;
    bool keepPlaying = true;
    void Start()
    {
        StartCoroutine(SoundOut());
    }
    IEnumerator SoundOut()
    {
        while (keepPlaying)
        {
            if (GameObject.FindWithTag("GameObject").GetComponent<SpecificScript>().enabled == true)
            {
                AudioSource myAudioSource = GameObject.FindWithTag("GameObject").GetComponent<AudioSource>();
                myAudioSource.PlayOneShot(myAudioSource.clip);
                yield return new WaitForSeconds(wait);
            }
        }
    }
