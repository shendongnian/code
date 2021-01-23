    AudioSource audioSrc;
    
        // Use this for initialization
        void Start()
        {
            if(audioSrc == null) audioSrc = new AudioSource();
            StartCoroutine(LoadTrack(Path.Combine(Application.streamingAssetsPath, "Track.ogg")));
        }
    
        IEnumerator LoadTrack(string filename)
        {
            var www = new WWW(filename);
            
            //Wait for file finish loading
            while(!www.isDone)
            {
                Debug.LogFormat("Progress loading {0}: {1}", filename, www.progress);
                yield return null;
            }
    
            var clip = www.GetAudioClip(false, true, AudioType.OGGVORBIS);
    
            audioSrc.clip = clip;
            audioSrc.Play();
        }
    
        // Update is called once per frame
        void Update()
        {
    
        }
