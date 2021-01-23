    public GameObject go = GameObject.Find("MyGameObjectAudioSource");
    void Update()
    {
         go.GetComponent<AudioSource>().volume = 0.5f;
    }
