    protected override void Update(Game Time gameTime)
    {
        // ...
        
        if (playSound)
        {
            if (_sfx == null)
            {
                Content.Load<SoundEffect>("noise.wav");
            }
            _sfx.Play();
        }
    }
