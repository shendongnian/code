    public class ItemClass
    {
    	public int ID;
    	public string Name;
    	public int Points;
    	public Texture2D Texture;
    	
    	public ItemClass(int pID, int pName, int pPoints, int pTetxure2D)
    	{
    		this.ID = pID;
    		this.Name = pName;
    		this.Points = pPoints;
    		this.Texture = pTexture;
    	}
    	
    	public Item New()
    	{
    		return new Item(this.ID);
    	}
    }
