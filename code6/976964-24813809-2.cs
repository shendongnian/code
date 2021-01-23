    public String Name { get; set; }
    public String Machine { get; set; }
    public Int32 Value { get; set; }
    public override bool Equals( object other ) 
    {
        Entry otherEntry = other as Entry;
        if ( otherEntry == null ) { return false; }
        return 
            otherEntry.Name.Equals( this.Name ) &&
            otherEntry.Machine.Equals( this.name ) &&
            otherEntry.Value.Equals( this.Value );
     }
     public override int GetHashCode()
     {
          // Thanks Jon Skeet
          unchecked // Overflow is fine, just wrap
          {
              int hash = (int) 2166136261;
              hash = hash * 16777619 ^ this.Name.GetHashCode();
              hash = hash * 16777619 ^ this.Machine.GetHashCode();
              hash = hash * 16777619 ^ this.Value.GetHashCode();
              return hash;
          }
      }
