    [Flags]
    public enum SaveStates
    {
        Saved = 1,
        WithChanges = 2,
        SavedWithoutChanges = Saved, // a bit pointless! Its the same as Saved
        SavedWithChanges = Saved | WithChanges  // has value "3"
    }
