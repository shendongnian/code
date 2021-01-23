    for (var length = PossibleTargets.Count(); length > 0; length--)
    {
        foreach (var combination in PossibleTargets.Combinations(length))
        {
            foreach (var permutation in combination.Permutations())
            {
                List<Card> Targets = new List<Card>(permutation);
                Out.Add(new GameDecision() { Type = GameDecisionType.PlayCard, TheCard = SpellCard, Targets = Targets });
            }
        }
    }
