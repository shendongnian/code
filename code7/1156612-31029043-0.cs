    public class Human
    {
      private Human _mother;
      private Human _father;
      private HashSet<Human> _children;
      public IEnumerable<Human> Children
      {
        // If paranoid, do a foreach … yield here to stop code casting back to `HashSet`
        // Using ImmutableCollections and calling ToImmutableHashSet() is good too.
        get { return _children; } 
      }
      public Human Mother
      {
        get { return _mother; }
        set
        {
          if(_mother == value) // skip for no-op
            return;
          if(_mother != null)
            _mother._children.Remove(this);
          if(value != null)
            value._children.Add(this);
          _mother = value;
        }
      }
      public Human Father
      {
        get { return _father; }
        set
        {
          if(_father == value)
            return;
          if(_father != null)
            _father._children.Remove(this);
          if(value != null)
            value._children.Add(this);
          _father = value;
        }
      }
    }
