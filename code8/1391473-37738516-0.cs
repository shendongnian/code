    public class Player
    {
	    public override bool Equals(object obj)
      	{
		    var other = obj as Player;
   		    if (other == null)
			    return false;
  		    return this.Name == other.Name;
	    }
	    public override int GetHashCode()
	    {
		    return this.Name.GetHashCode();
	    }
        public string Name;
    }
  
