    public static class ExtensionMethods
    {
        public static void AddRange(this ObservableCollection<DupInfo> value, List<DupInfo> list)
        {
            foreach (var dup in list)
                value.Add(dup);
        }
    }
