    for (var length = PossibleTargets.Count(); length > 0; length--)
    {
        foreach (var combination in PossibleTargets.Combinations(length))
        {
            List<Card> Targets = new List<Card>(combination);
            Out.Add(new GameDecision() { Type = GameDecisionType.PlayCard, TheCard = SpellCard, Targets = Targets });
        }
    }
