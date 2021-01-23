    var length = X;
    foreach (var combination in PossibleTargets.Combinations(length))
    {
        List<Card> Targets = new List<Card>(combination);
        Out.Add(new GameDecision() { Type = GameDecisionType.PlayCard, TheCard = SpellCard, Targets = Targets });
    }
