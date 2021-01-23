    public class LevelComparer : IComparer<Level>, IComparer
    {
        #region IComparer<Level> Members
        public int Compare(Level x, Level y)
        {
            if (object.ReferenceEquals(x, y))
                return 0;
            if (x == null)
                return 1;
            else if (y == null)
                return -1;
            return x.LevelID.CompareTo(y.LevelID);
        }
        #endregion
        #region IComparer Members
        public int Compare(object x, object y)
        {
            return Compare(x as Level, y as Level);
        }
        #endregion
    }
