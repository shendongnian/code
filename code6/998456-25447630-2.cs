        public IEnumerable<TValue> Mix<TValue>(IEnumerable<TValue> a, IEnumerable<TValue> b)
        {
            var aEnumerator = a.GetEnumerator();
            var bEnumerator = b.GetEnumerator();
            while (true)
            {
                if (!aEnumerator.MoveNext())
                {
                    yield break;
                }
                yield return aEnumerator.Current;
                if (!aEnumerator.MoveNext())
                {
                    yield break;
                }
                yield return aEnumerator.Current;
                if (!bEnumerator.MoveNext())
                {
                    yield break;
                }
                yield return bEnumerator.Current;
            }
        }
