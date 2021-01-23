    public class ListViewColumnSorterAsc : IComparer<data>
    {
		private Sorting_Mode srtMode;
		public ListViewColumnSorterAsc(Sorting_Mode srtMode) 
        {
			this.srtMode = srtMode;
		}
		public int Compare(data x, data y) 
        {
			switch (srtMode) {
				case Sorting_Mode.by_Name:
					return x.Name.CompareTo(y.Name);
				case Sorting_Mode.by_Size:
					return x.Size.CompareTo(y.Size);
				case Sorting_Mode.by_Date:
					return x.Date.CompareTo(y.Date);
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
