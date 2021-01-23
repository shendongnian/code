    public static class ComboModel {
        private static readonly ReadOnlyDictionary<int, int[]> _items = new ReadOnlyDictionary<int, int[]>(new Dictionary<int, int[]> {
            {
                1,
                new[] {
                    2,
                    3,
                    4
                }
            }
        });
        public static IReadOnlyDictionary<int, int[]> Items
        {
            get { return _items; }
        }
    }
