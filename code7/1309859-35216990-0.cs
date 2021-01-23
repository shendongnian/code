    private class GridSort : System.Collections.IComparer
    {
        List<GridSortData> ColIndexSorts = new List<GridSortData>();
        public GridSort(List<GridSortData> ColIndexSorts)
        {
            this.ColIndexSorts = ColIndexSorts;
        }
        public int Compare(object x, object y)
        {
            FormGridRow FirstComparable = (FormGridRow)x;
            FormGridRow SecondComparable = (FormGridRow)y;
            for (int i = 0; i < ColIndexSorts.Count; ++i)
            {
                int index = ColIndexSorts[i].ColumnSortIndex;
                object a = FirstComparable.Cells[index].Value;
                object b = SecondComparable.Cells[index].Value;
                int result = a.ToString().CompareTo(b.ToString());
                if (result != 0)
                {
                    if (ColIndexSorts[i].SortOrder == SortOrder.Ascending)
                    {
                        return result;
                    }
                    else
                    {
                        return -result;
                    }
                }
            }
            return 0;
        }
    }
