    DoubleAnimation db = new DoubleAnimation();
    db.From = 0;
    db.To = grid.ActualHeight;
    db.Duration = TimeSpan.FromSeconds(0.5);
    borderTransform.BeginAnimation(TranslateTransform.YProperty, db);
