    public void Draw(IDrawingService MyDrawingService)
    {
        using (var session = MyDrawingService.Begin())
        {
            _background.Draw(session);    
            ...
        }
    }
