        public IEnumerable<TValue> Mix<TValue>(IEnumerable<TValue> A, IEnumerable<TValue> B)
        {
            var aEnumerator = A.GetEnumerator();
            var bEnumerator = A.GetEnumerator();
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
                if (bEnumerator.MoveNext())
                {
                    yield break;
                }
                yield return bEnumerator.Current;
            }
        }
