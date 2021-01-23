    public void SwitchMode(Mode mode)
    {
        foreach (var m in _tabDict)
        {
            if (m.Value == Mode.Start)
            {
                AddTabPage(m.Key);
            }
            if (m.Value == Mode.Test)
            {
                AddTabPage(m.Key);
            }
            if (m.Value == Mode.Config)
            {
                AddTabPage(m.Key);
            }
    
        }
    }
