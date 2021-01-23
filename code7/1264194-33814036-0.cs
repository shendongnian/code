    public class Root
	{
		public int Value1;
		public int Value2;
		public List<NestedA> NestedAList;
        public override bool Equals(object obj)
        {
            Root other = obj as Root;
            if (other == null) return false;
            return this.Value1 == other.Value1 && this.Value2 == other.Value2 && this.NestedAList.SequenceEqual(other.NestedAList);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hasha = 19;
                foreach (NestedA na in NestedAList)
                {
                    hasha = hasha * 31 + na.GetHashCode();
                }
                return (Value1 ^ Value1 ^ hasha).GetHashCode();
            }               
        }
	}
	
	public class NestedA
	{
	    public List<NestedB> NestedBList;
	    public List<NestedC> NestedCList;
        public override bool Equals(object obj)
        {
            NestedA other = obj as NestedA;
            if (other == null) return false;
            return NestedBList.SequenceEqual(other.NestedBList) && NestedCList.SequenceEqual(other.NestedCList);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hashb = 19;
                foreach (NestedB nb in NestedBList)
                {
                    hashb = hashb * 31 + nb.GetHashCode();
                }
                int hashc = 19;
                foreach (NestedC nc in NestedCList)
                {
                    hashc = hashc * 31 + nc.GetHashCode();
                }
                return (hashb ^ hashc).GetHashCode();
            }            
        }
	}
	
	public class NestedB{
	     public int ValueB;
	     public int ValueB2;
         public override bool Equals(object obj)
         {
             NestedB other = obj as NestedB;
             if (other == null) return false;
             return this.ValueB == other.ValueB && this.ValueB2 == other.ValueB2;
         }
         public override int GetHashCode()
         {
             return (ValueB ^ ValueB2).GetHashCode();
         }
	}
	
	public class NestedC{
	     public int ValueC;
	     public int ValueC2;
         public override bool Equals(object obj)
         {
             NestedC other = obj as NestedC;
             if (other == null) return false;
             return this.ValueC == other.ValueC && this.ValueC2 == other.ValueC2;
         }
         public override int GetHashCode()
         {
             return (ValueC ^ ValueC2).GetHashCode();
         }
	}
