    public class ReallyTremendousExplosions
    	{
    		public delegate void ExplosionFactory(ReallyTremendousExplosions source);
    
    		public Dictionary<string, ExplosionFactory> Explosions = new Dictionary<string, ExplosionFactory>
    		{
    			{ "huge", x => x.SomeMethod() },
    			{ "huger", x => x.SomeMethod() }
    		};
    
    		public void SomeMethod()
    		{
                  //Render massive explosions...
    		}
    	}
