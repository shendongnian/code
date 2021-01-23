    public AudioClip clip;
    private AudioSource _musicAudioSource;
    bool _musicAudioSourcePaused = false;
    
    void Awake()
    {
        if (_musicAudioSource == null)
        {
            _musicAudioSource = gameObject.AddComponent<AudioSource>();
            _musicAudioSource.loop = true;
            _musicAudioSource.clip = clip;
        }
    
        //Check if Audio is playing. Don't play if already playing. 
        if (!_musicAudioSource.isPlaying)
        {
            _musicAudioSource.Play();
        }
    }
    
    void OnApplicationPause(bool pauseStatus)
    {
        //Check if this is Pause
        if (pauseStatus)
        {
            //Pause Audio if it is playing
            if (_musicAudioSource.isPlaying)
            {
                _musicAudioSource.Pause();
    
                //Set to true so that we will detamine whether to Play() or UnPause() the music next time
                _musicAudioSourcePaused = true;
            }
        }
    
        //Check if this is Resume
        if (!pauseStatus)
        {
            //Make sure audio is not null. If null, getComponent again
            if (_musicAudioSource == null)
            {
                _musicAudioSource = gameObject.AddComponent<AudioSource>();
                _musicAudioSource.loop = true;
                _musicAudioSource.clip = clip;
            }
    
            //Check if we paused the audio then resume
            if (_musicAudioSourcePaused)
            {
                _musicAudioSource.UnPause();
    
                //Set to false so that we will detamine whether to Play() or UnPause() the music next time
                _musicAudioSourcePaused = false;
            }
    
            //Check if Audio is playing. Don't play if already playing. 
            if (!_musicAudioSource.isPlaying)
            {
                _musicAudioSource.Play();
            }
        }
    }
