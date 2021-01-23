	public class MyGameName : Microsoft.Xna.Framework.Game
	{
		private SpriteBatch spriteBatch;
		// other variable declarations
		
		// Add a declaration for gameWorld
		private GameWorld gameWorld;
		
		protected override Initialize()
		{
			// Add the following line to initialize your gameWorld instance
			gameWorld = new GameWorld();
		}
		
		// other existing code - your LoadContent, Update, Draw methods etc.
	}
