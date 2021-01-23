    public class NameEquality : IEqualityComparer<HashTag>{
	  public bool Equals(HashTag tag, HashTag tag2){
		return tag.Name == tag2.Name;
	  }
	
	  public int GetHashCode(HashTag tag){
		return tag.Name.GetHashCode();
	  }
    }
