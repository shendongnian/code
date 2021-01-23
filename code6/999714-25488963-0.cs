     public class LevelComparator: IComparer<Level> {
      public int CompareTo(Level a, Level b)
      {
        if (a.LevelID < b.LevelID)
        {
            return -1;
        }
        else if (a.LevelID == b.LevelID)
        {
            return 0;
        }
        else
            return 1;
      }
    }
