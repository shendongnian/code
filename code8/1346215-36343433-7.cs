    public static class ComboModel {
        private static readonly IReadOnlyDictionary<int, ReadOnlyCollection<int>> _items = new ReadOnlyDictionary<int, ReadOnlyCollection<int>>(new Dictionary<int, ReadOnlyCollection<int>> {
            {
                1,
                Array.AsReadOnly(new[] {
                    2,
                    3,
                    4
                })
            }
        });
        public static IReadOnlyDictionary<int, ReadOnlyCollection<int>> Items
        {
            get { return _items; }
        }
    }
