    public string Format<T>(T value) {
        if (##item is dictionary) {
            var items = name.GetType().GetProperty("Keys", BindingFlags.Instance | BindingFlags.Public).GetValue(item) as IEnumerable;
            if (items == null) throw new ArgumentException("Dictionary with no keys?");
            string[] data = items.OfType<object>().Select(o => o.ToString()).ToArray();
        }
    }
