    foreach (var permutation in PossibleTargets.Permutations())
    {
        List<Card> Targets = new List<Card>(permutation);
        Out.Add(new GameDecision() { Type = GameDecisionType.PlayCard, TheCard = SpellCard, Targets = Targets });
    }
