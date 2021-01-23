    public static IEnumerable<T> ShuffleNoSameAdjacent<T>(IEnumerable<T> source,
        Random random = null, IEqualityComparer<T> comparer = null)
    {
        if (source == null) yield break;
        if (random == null) random = new Random();
        if (comparer == null) comparer = EqualityComparer<T>.Default;
        var grouped = source
            .GroupBy(i => i, comparer)
            .OrderByDescending(g => g.Count());
        var piles = Enumerable.Range(0, 3).Select(i => new Pile<T>()).ToArray();
        foreach (var group in grouped)
        {
            GetSmallestPile().AddRange(group);
        }
        int totalCount = piles.Select(e => e.Count).Sum();
        if (piles.Any(pile => pile.Count > (totalCount + 1) / 2))
        {
            throw new InvalidOperationException("Shuffle is impossible.");
        }
        piles.ForEach(pile => Shuffle(pile));
        Pile<T> previouslySelectedPile = null;
        while (totalCount > 0)
        {
            var selectedPile = GetRandomPile_WeightedByLength();
            yield return selectedPile[selectedPile.Count - 1];
            selectedPile.RemoveAt(selectedPile.Count - 1);
            totalCount--;
            previouslySelectedPile = selectedPile;
        }
        List<T> GetSmallestPile()
        {
            List<T> smallestPile = null;
            int smallestCount = Int32.MaxValue;
            foreach (var pile in piles)
            {
                if (pile.Count < smallestCount)
                {
                    smallestPile = pile;
                    smallestCount = pile.Count;
                }
            }
            return smallestPile;
        }
        void Shuffle(List<T> pile)
        {
            for (int i = 0; i < pile.Count; i++)
            {
                int j = random.Next(i, pile.Count);
                if (i == j) continue;
                var temp = pile[i];
                pile[i] = pile[j];
                pile[j] = temp;
            }
        }
        Pile<T> GetRandomPile_WeightedByLength()
        {
            var eligiblePiles = piles
                .Where(pile => pile.Count > 0 && pile != previouslySelectedPile)
                .ToArray();
            Debug.Assert(eligiblePiles.Length > 0, "No eligible pile.");
            eligiblePiles.ForEach(pile =>
            {
                pile.Proximity = ((totalCount + 1) / 2) - pile.Count;
                pile.Score = 1;
            });
            Debug.Assert(eligiblePiles.All(pile => pile.Proximity >= 0),
                "A pile has negative proximity.");
            foreach (var pile in eligiblePiles)
            {
                foreach (var otherPile in eligiblePiles)
                {
                    if (otherPile == pile) continue;
                    pile.Score *= otherPile.Proximity;
                }
            }
            var sumScore = eligiblePiles.Select(p => p.Score).Sum();
            while (sumScore > Int32.MaxValue)
            {
                eligiblePiles.ForEach(pile => pile.Score /= 100);
                sumScore = eligiblePiles.Select(p => p.Score).Sum();
            }
            if (sumScore == 0)
            {
                return eligiblePiles[random.Next(0, eligiblePiles.Length)];
            }
            var randomScore = random.Next(0, (int)sumScore);
            int accumulatedScore = 0;
            foreach (var pile in eligiblePiles)
            {
                accumulatedScore += (int)pile.Score;
                if (randomScore < accumulatedScore) return pile;
            }
            Debug.Fail("Could not select a pile randomly by weight.");
            return null;
        }
    }
    private class Pile<T> : List<T>
    {
        public int Proximity { get; set; }
        public long Score { get; set; }
    }
This implementation can suffle millions of elements. I am not completely convinced that the quality of the suffling is as perfect as the previous probabilistic implementation, but should be close.
