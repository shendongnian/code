    [Flags]
    public enum SaveStates
    {
        Saved = 1,
        SavedWithChanges = 3,
        SavedWithoutChanges = 5
    }
    if ((lastState & SaveStates.Saved) == SaveStates.Saves)
    {
    }
