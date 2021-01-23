    static IEnumerable<T> Alternate<T>(IEnumerable<T> sourceA, IEnumerable<T> sourceB) {
        using (IEnumerator<T> eA = sourceA.GetEnumerator(), eB = sourceB.GetEnumerator()) {
            bool stillItems = true; 
            while (stillItems) {
                if (eA.MoveNext()) yield return eA.Current;
                if ((stillItems = eA.MoveNext())) yield return eA.Current;
                if ((stillItems |= eB.MoveNext())) yield return eB.Current;
            }
        }
    }
