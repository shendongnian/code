    public CoolGame : Game
    {
    	private Dictionary<int, ItemClass> itemClasses; // each item class should nave unique ID
    	private List<Item> items; // real items; better also make as dictionary with unique ID for each
    	private SpriteBatch spriteBatch;
    	
        // call in LoadContent to register all item classes you want use in game
    	private LoadItemClasses()
    	{
    		this.itemClasses = new Dictionary<int, ItemClass>();
    		this.itemClasses.Add(0, new ItemClass(0, "Silver coin", 1, silver_coin_texture));
    		this.itemClasses.Add(1, new ItemClass(1, "Gold Coin", 3, gold_coin_texture));
    		this.itemClasses.Add(2, new ItemClass(2, "Diamond", 10, diamond_texture));
    		this.itemClasses.Add(3, new ItemClass(3, "Anchor", -5, anchor_texture));
    		/// and so on...
    		
    		this.items = new List<Item>();
    	}
        // call to create real item that you can draw and catch
    	private void CreateRandomItem()
    	{
    		Vector2D randomPosition = ...;
    		int randomItemClassID = ...;
    		ItemClass itemClass = this.itemClasses[randomItemClassID];
    		Item item = itemClass.New();
    		item.Position = randomPosition;
    		this.items.Add(item);
    	}
    	
    	private void UpdateItems()
    	{
    		foreach (Item item in this.items)
    		{
    			// update item position, check collision and so on
    		}
    	}
    	
        // you use position from item, but texture from itemClass, so you can use only one Texture2D object for whole your items of this class
    	private void DrawItems()
    	{
    		ItemClass itemClass = null;
    		this.spriteBatch.Begin();
    		foreach (Item item in this.items)
    		{
    			itemClass = this.itemClasses[item.ClassID];
    			spriteBatch.Draw(itemClass.Texture, item.Position, color.White);
    		}
    		
    		this.spriteBatch.End();
    	}
    }
