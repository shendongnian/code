    public interface IHasParts
    {
    	ICollection Parts { get; }
    }
    
    public abstract class HasParts<TCollectionType, TPartType> : IHasParts where TCollectionType : ICollection
    {
    	
    	public TCollectionType Parts;
    	
    	
    	ICollection IHasParts.Parts { get { return this.Parts; } }
    	
    }
    
    public class CarPart
    {
    	//...
    }
    
    public class Car : HasParts<List<CarPart>, CarPart>
    {
    	protected void AddParts()
    	{
    		this.Parts.Add(new CarPart());
    	}
    }
