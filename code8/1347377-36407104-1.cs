    void OnTriggerEnter2D(Collider2D hitObject)
    {
        //if the laser hits a bad guy, play the audio clip attached to the bad guy
        AudioSource hitAudio = hitObject.GetComponent<AudioSource>();
        hitAudio.PlayOneShot(hitAudio.clip);
        Destroy(hitObject.gameObject);
        Destroy(gameObject);
    }
