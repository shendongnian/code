    vsg.States.Add(vs);
    vs = new VisualState();
    vs.StateTriggers.Add(new AdaptiveTrigger
    {
        MinWindowWidth = 0,
    });
    vsg.States.Add(vs);
