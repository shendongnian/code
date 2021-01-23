    void OnGUI()
    {
        var typeBackup = Event.current.type;
        switch (Event.current.type)
        {
            case EventType.MouseDown:
                Debug.Log(Event.current);
                Event.current.type = EventType.Ignore;
                break;
            case EventType.MouseUp:
                Debug.Log(Event.current);
                Event.current.type = EventType.MouseDown;
                break;
        }
        
        GUILayout.TextField("I will not steal focus on MouseDown");
        if (Event.current.type != EventType.Used)
            Event.current.type = typeBackup;
    }
