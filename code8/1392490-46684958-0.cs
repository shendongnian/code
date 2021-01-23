        public CachedSoundSampleProvider(CachedSound cachedSound, float volume = 1, float pan = 0)
        {
            this.cachedSound = cachedSound;
            LeftVolume = volume * (0.5f - pan / 2);
            RightVolume = volume * (0.5f + pan / 2);
        }
