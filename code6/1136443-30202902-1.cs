    DoubleAnimation anima = new DoubleAnimation
    {
        To = pageHostBaseIndex + 1,
        Duration = CalculateFractionalDuration(pageHostBaseIndex + 1),
        EnableDependentAnimation = true
    };
    Storyboard storyboard = new Storyboard();
    Storyboard.SetTarget(anima, this.PageTransition);
    Storyboard.SetTargetProperty(anima, "PageTransition.FractionalBaseIndex");
