    public void DrawElements(Graphics graphics)
    {
        foreach (var actor in _actors)
        {
            DrawActor(graphics, actor);
        }
        foreach (var useCase in _useCases)
        {
            DrawUseCase(graphics, useCase);
        }
    }
