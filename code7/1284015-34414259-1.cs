    public static class DataGridViewExtensions
    {
        public static IEnumerable<DataGridViewRow> GetSelectedRows(this DataGridView source)
        {
            for (int i = source.SelectedRows.Count - 1; i >= 0; i--)
                yield return source.SelectedRows[i];
        }
    }
