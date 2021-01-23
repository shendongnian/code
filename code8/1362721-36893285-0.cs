    for (int i = 0; i < touchCollection.Count; i++)
    {
        InputPoints.Add(new Vector2
        (touchCollection[i].Position.X / Game1.ScalingFactor.X,
        touchCollection[i].Position.Y / Game1.ScalingFactor.Y));
    }
