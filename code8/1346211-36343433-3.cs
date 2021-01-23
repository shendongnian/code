    public static class ComboModel {
        private static readonly IReadOnlyDictionary<int, IReadOnlyCollection<int>> _items = new ReadOnlyDictionary<int, IReadOnlyCollection<int>>(new Dictionary<int, IReadOnlyCollection<int>> {
            {
                1,
                Array.AsReadOnly(new[] {
                    2,
                    3,
                    4
                })
            }
        });
        public static IReadOnlyDictionary<int, IReadOnlyCollection<int>> Items
        {
            get { return _items; }
        }
    }
