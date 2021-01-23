    static IEnumerable<T> Alternate<T>(IEnumerable<T> sourceA, IEnumerable<T> sourceB) {
        using (IEnumerator<T> eA = sourceA.GetEnumerator(), eB = sourceB.GetEnumerator()) {
            bool aHasItems = true, bHasItems = true; 
            while (aHasItems || bHasItems) {
                if (eA.MoveNext()) yield return eA.Current;
                if (aHasItems = eA.MoveNext()) yield return eA.Current;
                if (bHasItems = eB.MoveNext()) yield return eB.Current;
            }
        }
    }
