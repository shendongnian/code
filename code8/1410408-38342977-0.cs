    public int SearchArray(string searchTerm) {
        return arrayList.IndexOf(
        arrayList.Cast<string>()
        .FirstOrDefault(i => searchTerm.Contains(i)));
    }
