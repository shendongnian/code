    foreach (var gs in gsc)
    {
        var name = "GS_" + Guid.NewGuid().ToString("N");
        RegisterName(name, gs);
        Storyboard.SetTargetName(caukf, name);
    }
        
