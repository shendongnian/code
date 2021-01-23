    public void Update(GameTime gameTime)
    {
        if (!Game1.IsSoundDisabled)
        {
            if ((IsHovered) && (!IsDisabled))
                if (InputManager.Instance.IsLeftClicked())
                {
                    clickSFX.Play();
                    IsHovered = false;
                    
                    if(Click != null)
                        Click(this, EventArgs.Empty);
                }
        }
    }
