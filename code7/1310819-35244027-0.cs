    public abstract class TargetableUnit
    {
    	//Returns whether the object of a class that implements this interface is targetable
    	public bool unitCanBeTargeted()
    	{
    		bool targetable = false;
    		if (this is Insect)
    		{
    			targetable = (this as Insect).isFasterThanLight();
    		}
    		else if (this is FighterJet)
    		{
    			targetable = !(this as FighterJet).Flying;
    		}
    		else if (this is Zombie)
    		{
    			targetable = !(this as Zombie).Invisible;
    		}
    
    		return targetable;
    	}
    }
    
    public class Insect : TargetableUnit
    {
    	public bool isFasterThanLight()
    	{
    		return System.DateTime.UtcNow.Second == 0;
    	}
    }
    public class FighterJet : TargetableUnit
    {
    	public bool Flying { get; set; }
    }
    public class Zombie : TargetableUnit
    {
    	public bool Invisible { get; set; }
    }
