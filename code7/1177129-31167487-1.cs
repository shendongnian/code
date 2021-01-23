    public class Item
    {
        public virtual short MaxPerStack
        {
            get
            {
                return this.Data.MaxPerStack;
            }
        }
    }
    public class Equip : Item
    {
    	public override short MaxPerStack
    	{
    		get
    		{
    			return 1;
    		}
    	}
    }
