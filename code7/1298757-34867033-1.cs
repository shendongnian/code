    ...
    var processes = Process.GetProcessesByName("Hearthstone");
    foreach(Process p in processes) {
        if(activedHandle == p.Handle) {
            //A instance of the process Hearthstone is currently focused.
            ...
        } else {
            ...
        }
    }
