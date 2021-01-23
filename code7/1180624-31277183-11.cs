        private static Func<string, IEnumerable<string>> DontVisitMoreThanOnce(Func<string, IEnumerable<string>> naiveChildSource) {
             var alreadyVisited = new HashSet<string>();
             return s => {
                 if (alreadyVisited.Contains(s)) return Enumerable.Empty<string>();
                 alreadyVisited.Add(s);
                 return naiveChildSource(s);
             };
        }
