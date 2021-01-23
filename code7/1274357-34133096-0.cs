    if (Debugger.IsAttached) {
        Application.Current.Exit();
        // If Application.Exit fails, try...
        // CoreApplication.Exit();
    }
