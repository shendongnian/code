    private Dictionary<string, AudioClip> _audioClips { get; set; } = new Dictionary<string, AudioClip>();
    public AudioClip GetSoundCached(string wavFilePath, float initialVolumne, bool loopForever = false)
    {
        lock (_audioClips)
        {
            AudioClip result = null;
    
            wavFilePath = wavFilePath.ToLower();
    
            if (_audioClips.ContainsKey(wavFilePath))
            {
                result = _audioClips[wavFilePath];
            }
            else
            {
                result = new AudioClip(wavFilePath, initialVolumne, loopForever);
                _audioClips.Add(wavFilePath, result);
            }
    
            return result;
        }
    }
