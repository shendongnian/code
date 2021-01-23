    protected override void Update(GameTime gameTime)
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
