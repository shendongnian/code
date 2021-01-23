	using System.Collections.Generic;
	using System.Linq;
	using Microsoft.Xna.Framework.Input;
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Graphics;
	namespace F.U.N
	{
		public class SplashScreenManager
		{
			private List<SplashScreen> screens;
			private Keys skipButton;
			public bool Running
			{
				get
				{
					foreach (SplashScreen s in screens)
						if (s.CurrentStatus != SplashScreen.Status.NotReady)
							return true;
					return false;
				}
			}
			public SplashScreenManager() : this(new List<SplashScreen>(), Keys.None) { }
			public SplashScreenManager(List<SplashScreen> screens, Keys skipButton)
			{
				this.screens = screens;
				this.skipButton = skipButton;
				Prepare();
			}
			public SplashScreenManager(string path, float fadeIn, float wait, float fadeOut, Keys skipButton)
			{
				List<Texture2D> images = GContent.Textures(path);
				screens = new List<SplashScreen>();
				foreach (Texture2D t in images)
					screens.Add(new SplashScreen(t, fadeIn, wait, fadeOut));
				this.skipButton = skipButton;
			}
			public void Prepare()
			{
				foreach (SplashScreen s in screens)
					s.Prepare();
			}
			public void Update(GameTime gt)
			{
				for (int i = 0; i < screens.Count(); i++)
				{
					if (screens[i].CurrentStatus != SplashScreen.Status.NotReady)
					{
						screens[i].Update(gt);
						if (KState.Clicked(skipButton)) screens[i].End();
						break;
					}
				}
			}
			public void Draw(SpriteBatch sp)
			{
				for (int i = 0; i < screens.Count(); i++)
				{
					if (screens[i].CurrentStatus != SplashScreen.Status.NotReady)
					{
						screens[i].Draw(sp);
						break;
					}
				}
			}
		}
	}
