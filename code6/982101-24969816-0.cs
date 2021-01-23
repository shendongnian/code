    public void Update()
    {
        base.Update();
        if (Keyboard.GetState().IsKeyDown(Keys.Space))               
        {
            bullets.Add(planeVec);
        }
    }
