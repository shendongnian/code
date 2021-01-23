    set
    {
        CalculateCharacterPointsRemaining();
        if (value <= CharacterPointsAvailable)
        {
            NewCharacter.CharacterDefense = value;
        }
        if (value > CharacterPointsAvailable)
        {
            NewCharacter.CharacterDefense = CharacterPointsAvailable;
        }
        CalculateCharacterPointsRemaining();
        OnPropertyChanged();
    }
