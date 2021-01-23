    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace XNA_bus
    {
    	internal static class GameElements
    	{
    		public enum State
    		{
    			Menu,
    			Levels,
    			Level1,
    			Level2,
    			Level3,
    			Run,
    			Highscore,
    			Quit
    		}
    
    		private static Meny meny;
    
    		private static Levels levels;
    
    		private static Player player;
    
    		private static List<Fiender> Fiende;
    
    		private static List<GuldMynt> guldMynt;
    
    		private static List<Powerup> SuperSkepp;
    
    		private static List<Powerup> PenetratingBullets;
    
    		private static Texture2D guldMyntSprite;
    
    		private static Texture2D SuperskeppSprite;
    
    		private static Texture2D PenetratingbulletsSprite;
    
    		private static Utskrifter printText;
    
    		private static Bakgrund bakgrund;
    
    		private static Boss1 boss1;
    
    		private static int boss1Liv = 3;
    
    		private static int playerLiv = 1;
    
    		public static GameElements.State currentState;
    
    		public static void Initialize()
    		{
    			GameElements.guldMynt = new List<GuldMynt>();
    			GameElements.SuperSkepp = new List<Powerup>();
    			GameElements.PenetratingBullets = new List<Powerup>();
    		}
    
    		public static void LoadContent(ContentManager content, GameWindow window)
    		{
    			GameElements.player = new Player(content.Load<Texture2D>("Images/player/Player"), 0f, 200f, 2.5f, 4.5f, content.Load<Texture2D>("Images/player/bullet"));
    			GameElements.bakgrund = new Bakgrund(content.Load<Texture2D>("Images/bakgrund"), window);
    			GameElements.boss1 = new Boss1(content.Load<Texture2D>("Images/Enemies/Boss1"), 700f, 360f);
    			GameElements.meny = new Meny(0);
    			GameElements.meny.AddItem(content.Load<Texture2D>("Images/Meny/Start"), 1, window);
    			GameElements.meny.AddItem(content.Load<Texture2D>("Images/Meny/Highscore"), 6, window);
    			GameElements.meny.AddItem(content.Load<Texture2D>("Images/Meny/Avsluta"), 7, window);
    			GameElements.levels = new Levels(1);
    			GameElements.levels.AddItem(content.Load<Texture2D>("Images/Meny/Level 1"), 2, window);
    			GameElements.levels.AddItem(content.Load<Texture2D>("Images/Meny/Level 2"), 3, window);
    			GameElements.levels.AddItem(content.Load<Texture2D>("Images/Meny/Level 3"), 4, window);
    			GameElements.Fiende = new List<Fiender>();
    			Random random = new Random();
    			Texture2D tmpsprite = content.Load<Texture2D>("Images/Enemies/Predator");
    			for (int i = 0; i < 5; i++)
    			{
    				int rndX = random.Next(window.get_ClientBounds().Width / 2, window.get_ClientBounds().Width - tmpsprite.get_Width());
    				int rndY = random.Next(0, window.get_ClientBounds().Height - tmpsprite.get_Height());
    				Predator temp = new Predator(tmpsprite, (float)rndX, (float)rndY);
    				GameElements.Fiende.Add(temp);
    			}
    			tmpsprite = content.Load<Texture2D>("Images/Enemies/mina");
    			for (int i = 0; i < 5; i++)
    			{
    				int rndX = random.Next(window.get_ClientBounds().Width / 2, window.get_ClientBounds().Width - tmpsprite.get_Width());
    				int rndY = random.Next(0, window.get_ClientBounds().Height - tmpsprite.get_Height());
    				Mine temp2 = new Mine(tmpsprite, (float)rndX, (float)rndY);
    				GameElements.Fiende.Add(temp2);
    			}
    			GameElements.printText = new Utskrifter(content.Load<SpriteFont>("Font1"));
    			GameElements.guldMyntSprite = content.Load<Texture2D>("Images/Powerups/SpelMynt");
    			GameElements.SuperskeppSprite = content.Load<Texture2D>("Images/Powerups/PowerUp");
    			GameElements.PenetratingbulletsSprite = content.Load<Texture2D>("Images/Powerups/PowerUp2");
    		}
    
    		public static GameElements.State MenyUpdate(GameTime gameTime)
    		{
    			return (GameElements.State)GameElements.meny.Update(gameTime);
    		}
    
    		public static void MenyDraw(SpriteBatch spriteBatch)
    		{
    			GameElements.bakgrund.Draw(spriteBatch);
    			GameElements.meny.Draw(spriteBatch);
    		}
    
    		public static GameElements.State RunUpdate(ContentManager content, GameWindow window, GameTime gameTime)
    		{
    			GameElements.bakgrund.Update(window);
    			GameElements.player.Update(window, gameTime);
    			foreach (Fiender f in GameElements.Fiende.ToList<Fiender>())
    			{
    				foreach (Bullet b in GameElements.player.AntSkott.ToList<Bullet>())
    				{
    					if (f.CheckCollision(b))
    					{
    						f.Liv = false;
    						GameElements.player.poäng++;
    						if (!GameElements.player.PenetratingBullets)
    						{
    							GameElements.player.AntSkott.Remove(b);
    						}
    						else if (GameElements.player.PenetratingBullets)
    						{
    							if (gameTime.get_TotalGameTime().TotalSeconds > GameElements.player.PenetratingBulletsTime + 2.0)
    							{
    								GameElements.player.PenetratingBullets = false;
    							}
    						}
    					}
    				}
    				if (f.Liv)
    				{
    					if (f.CheckCollision(GameElements.player))
    					{
    						GameElements.playerLiv--;
    						GameElements.player.Liv = false;
    					}
    					f.Update(window);
    				}
    				else
    				{
    					GameElements.Fiende.Remove(f);
    				}
    				if (!f.FKoll)
    				{
    					GameElements.Fiende.Remove(f);
    					GameElements.playerLiv--;
    				}
    			}
    			if (GameElements.boss1.Liv)
    			{
    				foreach (Bullet b in GameElements.player.AntSkott.ToList<Bullet>())
    				{
    					if (GameElements.boss1.CheckCollision(b))
    					{
    						GameElements.player.AntSkott.Remove(b);
    						GameElements.boss1Liv--;
    					}
    				}
    				GameElements.boss1.Update(window);
    			}
    			if (GameElements.boss1Liv == 0)
    			{
    				GameElements.boss1.Liv = false;
    			}
    			GameElements.State result;
    			if (!GameElements.boss1.Liv)
    			{
    				GameElements.Reset(window, content);
    				result = GameElements.State.Menu;
    			}
    			else
    			{
    				Random random = new Random();
    				int newMynt = random.Next(1, 200);
    				if (newMynt == 1)
    				{
    					int rndX = random.Next(0, window.get_ClientBounds().Width - GameElements.guldMyntSprite.get_Width());
    					int rndY = random.Next(0, window.get_ClientBounds().Height - GameElements.guldMyntSprite.get_Height());
    					GameElements.guldMynt.Add(new GuldMynt(GameElements.guldMyntSprite, (float)rndX, (float)rndY));
    				}
    				foreach (GuldMynt gc in GameElements.guldMynt.ToList<GuldMynt>())
    				{
    					if (gc.Liv)
    					{
    						gc.Update(gameTime);
    						if (gc.CheckCollision(GameElements.player))
    						{
    							GameElements.guldMynt.Remove(gc);
    							GameElements.player.Poäng++;
    						}
    					}
    					else
    					{
    						GameElements.guldMynt.Remove(gc);
    					}
    				}
    				Random rnd = new Random();
    				int newPowerup = rnd.Next(1, 300);
    				if (newPowerup == 1)
    				{
    					int rndX = rnd.Next(0, window.get_ClientBounds().Width - GameElements.SuperskeppSprite.get_Width());
    					int rndY = rnd.Next(0, window.get_ClientBounds().Height - GameElements.SuperskeppSprite.get_Height());
    					GameElements.SuperSkepp.Add(new Powerup(GameElements.SuperskeppSprite, (float)rndX, (float)rndY));
    				}
    				foreach (Powerup Power in GameElements.SuperSkepp.ToList<Powerup>())
    				{
    					if (Power.Liv)
    					{
    						Power.Update(gameTime);
    						if (Power.CheckCollision(GameElements.player))
    						{
    							GameElements.SuperSkepp.Remove(Power);
    							GameElements.player.SuperSkepp = true;
    							GameElements.player.SuperSkeppTime = gameTime.get_TotalGameTime().TotalSeconds;
    						}
    					}
    					else
    					{
    						GameElements.SuperSkepp.Remove(Power);
    					}
    				}
    				Random rnd2 = new Random();
    				int NewPowerup = rnd2.Next(1, 300);
    				if (NewPowerup == 1)
    				{
    					int rndX = rnd2.Next(0, window.get_ClientBounds().Width - GameElements.PenetratingbulletsSprite.get_Width());
    					int rndY = rnd2.Next(0, window.get_ClientBounds().Height - GameElements.PenetratingbulletsSprite.get_Height());
    					GameElements.PenetratingBullets.Add(new Powerup(GameElements.PenetratingbulletsSprite, (float)rndX, (float)rndY));
    				}
    				foreach (Powerup P in GameElements.PenetratingBullets.ToList<Powerup>())
    				{
    					if (P.Liv)
    					{
    						P.Update(gameTime);
    						if (P.CheckCollision(GameElements.player))
    						{
    							GameElements.PenetratingBullets.Remove(P);
    							GameElements.player.PenetratingBullets = true;
    							GameElements.player.PenetratingBulletsTime = gameTime.get_TotalGameTime().TotalSeconds;
    						}
    					}
    					else
    					{
    						GameElements.PenetratingBullets.Remove(P);
    					}
    				}
    				if (!GameElements.player.Liv || GameElements.playerLiv == 0)
    				{
    					GameElements.Reset(window, content);
    					result = GameElements.State.Menu;
    				}
    				else
    				{
    					result = GameElements.State.Run;
    				}
    			}
    			return result;
    		}
    
    		public static void RunDraw(SpriteBatch spriteBatch)
    		{
    			GameElements.boss1.Draw(spriteBatch);
    			GameElements.bakgrund.Draw(spriteBatch);
    			GameElements.player.Draw(spriteBatch);
    			foreach (Fiender f in GameElements.Fiende)
    			{
    				f.Draw(spriteBatch);
    			}
    			foreach (GuldMynt gc in GameElements.guldMynt)
    			{
    				gc.Draw(spriteBatch);
    			}
    			foreach (Powerup Power in GameElements.SuperSkepp)
    			{
    				Power.Draw(spriteBatch);
    			}
    			foreach (Powerup p in GameElements.PenetratingBullets)
    			{
    				p.Draw(spriteBatch);
    			}
    			GameElements.printText.Print("Points:" + GameElements.player.poäng, spriteBatch, 0, 0);
    			GameElements.printText.Print("Boss Liv:" + GameElements.boss1Liv, spriteBatch, 680, 0);
    			GameElements.printText.Print("Liv:" + GameElements.playerLiv, spriteBatch, 0, 20);
    		}
    
    		public static GameElements.State HighScoreUpdate()
    		{
    			GameElements.State result;
    			if (Keyboard.GetState().IsKeyDown(27))
    			{
    				result = GameElements.State.Menu;
    			}
    			else
    			{
    				result = GameElements.State.Highscore;
    			}
    			return result;
    		}
    
    		public static void HighScoreDraw(SpriteBatch spriteBatch)
    		{
    		}
    
    		private static void Reset(GameWindow window, ContentManager content)
    		{
    			GameElements.boss1Liv = 3;
    			GameElements.playerLiv = 1;
    			GameElements.boss1.Liv = true;
    			GameElements.player.Reset(0f, 200f, 2.5f, 4.5f);
    			GameElements.Fiende.Clear();
    			Random random = new Random();
    			Texture2D tmpsprite = content.Load<Texture2D>("Images/Enemies/Predator");
    			for (int i = 0; i < 5; i++)
    			{
    				int rndX = random.Next(window.get_ClientBounds().Width / 2, window.get_ClientBounds().Width - tmpsprite.get_Width());
    				int rndY = random.Next(0, window.get_ClientBounds().Height - tmpsprite.get_Height());
    				Predator temp = new Predator(tmpsprite, (float)rndX, (float)rndY);
    				GameElements.Fiende.Add(temp);
    			}
    			tmpsprite = content.Load<Texture2D>("Images/Enemies/mina");
    			for (int i = 0; i < 5; i++)
    			{
    				int rndX = random.Next(window.get_ClientBounds().Width / 2, window.get_ClientBounds().Width - tmpsprite.get_Width());
    				int rndY = random.Next(0, window.get_ClientBounds().Height - tmpsprite.get_Height());
    				Mine temp2 = new Mine(tmpsprite, (float)rndX, (float)rndY);
    				GameElements.Fiende.Add(temp2);
    			}
    		}
    
    		public static GameElements.State LevelsUpdate(GameTime gameTime)
    		{
    			return (GameElements.State)GameElements.levels.Update(gameTime);
    		}
    
    		public static void LevelsDraw(SpriteBatch spritebatch)
    		{
    			GameElements.bakgrund.Draw(spritebatch);
    			GameElements.levels.Draw(spritebatch);
    		}
    	}
    }
