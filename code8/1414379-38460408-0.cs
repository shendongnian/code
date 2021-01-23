    void Main()
    {
    	var oldPrices = new List<Change> {
    	    new Change { Id = 1, Price = 1.5M },
    	    new Change { Id = 2, Price = 5.0M }
    	};
    		
    	var newPrices = new List<Change> {
    	    new Change { Id = 1, Price = 1.5M },
    	    new Change { Id = 2, Price = 5.75M }
    	};
    	
    	var list = newPrices.Except(oldPrices).ToDictionary(x => x.Id, x => x.Price);
    }
    
    public class Change : IEquatable<Change>
    {
        public int Id {get; set;}
        public decimal Price {get; set;}
    	
    	public bool Equals(Change other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            return Id.Equals(other.Id) && Price.Equals(other.Price);
        }
    	
    	public override int GetHashCode()
        {
            int hashId = Id.GetHashCode();
            int hashPrice = Price.GetHashCode();
            return hashId ^ hashPrice;
        }
    }
