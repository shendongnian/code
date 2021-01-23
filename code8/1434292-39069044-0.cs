    protected override void Update (GameTime gameTime)
    {
        // ...
        if (playSound)
        {
            // This is where the error is thrown
            // THIS ENSURES WHEN THIS METHOD IS INVOKED _sfx is initialized.
            _sfx = Content.Load<SoundEffect>("noise.wav");
            _sfx.Play();
        }
        // ...
    }
