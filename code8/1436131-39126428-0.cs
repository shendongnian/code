    public class modelMain : ViewModelBase, IEquatable<modelMain>
    {
      ...
      public bool Equals(modelMain other)
      {
        return (HexValue == other.HexValue);
      }
    }
