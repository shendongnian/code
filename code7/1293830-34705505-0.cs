    public abstract class Enemy
    {
    	protected abstract float Health { get; }
    }
    
    public class BadGuy : Enemy
    {
        private const int BadGuyHealth = 1;
    	protected override float Health
    	{
    		get { return BadGuyHealth; }
    	}
    }
    
    public class EvenWorseGuy : BadGuy
    {
        private const int WorseGuyHealth = 2;
    	protected override float Health
    	{
    		get { return WorseGuyHealth; }
    	}
    }
