    public class ReallyTremendousExplosions
    	{
    		private delegate void ExplosionFactory(ReallyTremendousExplosions source);
    
    		private Dictionary<string, ExplosionFactory> Explosions = new Dictionary<string, ExplosionFactory>()
    		{
    			{ "huge", x => x.SomeMethod() },
    			{ "huger", x => x.SomeMethod() }
    		};
    
    		private void SomeMethod()
    		{
                  //Render massive explosions...
    		}
    		public void RenderNamedExplosion(string explosionName) {
    		    ExplosionsFactory explosionFactory;
    		    if (!Explosions.TryGet(explosionName, out explosionFactory) {
    		    		throw new NoSuchExplosionException(explosionName);
    		    }
    		    explosionFactory(this);
    		}
    	}
    
