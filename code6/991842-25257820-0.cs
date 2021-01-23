    public override bool Equals(object obj) {
      if (NonParentEquals(obj)) {
        return((GridEntry)obj).ParentGridEntry == this.ParentGridEntry;
      }
      return false;
    }
    
    internal virtual bool NonParentEquals(object obj) {
      if (obj == this) return true;
      if (obj == null) return false;
      if (!(obj is GridEntry)) return false;
      GridEntry pe = (GridEntry)obj;
    
      return pe.PropertyLabel.Equals(this.PropertyLabel) &&
        pe.PropertyType.Equals(this.PropertyType) && pe.PropertyDepth == this.PropertyDepth;
    }
