    public int MaxCharacterDefense
    {
        get { return CharacterPointsAvailable; }
    }
    private void CharacterPointsAvailable()
    {
        // ... existing method logic
        OnPropertyChanged(nameof(MaxCharacterDefense));
    }
