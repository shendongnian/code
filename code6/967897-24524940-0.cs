    public class Fruit
    {
         private Vector2 pos;
         public Vector2 Position
         {
             get{return pos;}
    		 set{pos = value;}
         }
    	 public Texture2D Texture {get;set;}
    	 
    	 public Fruit(Texture2D tex, Vector2 pos)
    	 {
    		 Position = pos;
    		 Texture = tex;
    	 }
    }
    List<Fruit> kiwis = new List<Fruit>();
    
    kiwi = Content.Load<Texture2D>("Sprites/kiwi");
    if (kiwis.Count() < 4)
    {
    	kiwis.Add(new Kiwi(kiwiTex, 
                           new Vector2(random.Next(30, 610), random.Next(30, 450)));
    }
    
    foreach (Fruit kiwi in kiwis)
    {
        spriteBatch.Draw(kiwi.Texture, kiwi.Position, Color.White);  
    }
