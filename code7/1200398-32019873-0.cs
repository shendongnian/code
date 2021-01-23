    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace Test
    {
    	enum RenderMode { NewBitmap, PreallocatedBitmap, Graphics }
    	class Screen
    	{
    		Control canvas;
    		public Rectangle area;
    		int[,] pixels;
    		BitmapData info;
    		Bitmap bitmap;
    		BufferedGraphics buffer;
    		float scaleX, scaleY;
    		public RenderMode mode = RenderMode.NewBitmap;
    		public Screen(Control canvas, Size size)
    		{
    			this.canvas = canvas;
    			var bounds = canvas.DisplayRectangle;
    			scaleX = (float)bounds.Width / size.Width;
    			scaleY = (float)bounds.Height / size.Height;
    			area.Size = size;
    			info = new BitmapData { Width = size.Width, Height = size.Height, PixelFormat = PixelFormat.Format32bppRgb, Stride = size.Width * 4 };
    			pixels = new int[size.Height, size.Width];
    			bitmap = new Bitmap(size.Width, size.Height, info.PixelFormat);
    			buffer = BufferedGraphicsManager.Current.Allocate(canvas.CreateGraphics(), bounds);
    			buffer.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
    			ApplyMode();
    		}
    		public void ApplyMode()
    		{
    			buffer.Graphics.ResetTransform();
    			if (mode == RenderMode.Graphics)
    				buffer.Graphics.ScaleTransform(scaleX, scaleY);
    		}
    		public void FillRectangle(Color color, Rectangle rect)
    		{
    			if (mode == RenderMode.Graphics)
    			{
    				using (var brush = new SolidBrush(color))
    					buffer.Graphics.FillRectangle(brush, rect);
    			}
    			else
    			{
    				rect.Intersect(area);
    				if (rect.IsEmpty) return;
    				int colorData = color.ToArgb();
    				var pixels = this.pixels;
    				for (int y = rect.Y; y < rect.Bottom; y++)
    					for (int x = rect.X; x < rect.Right; x++)
    						pixels[y, x] = colorData;
    			}
    		}
    		public unsafe void Render()
    		{
    			if (mode == RenderMode.NewBitmap)
    			{
    				var bounds = canvas.DisplayRectangle;
    				using (var buffer = BufferedGraphicsManager.Current.Allocate(canvas.CreateGraphics(), bounds))
    				{
    					Bitmap bitmap;
    					fixed (int* pixels = &this.pixels[0, 0])
    						bitmap = new Bitmap(info.Width, info.Height, info.Stride, info.PixelFormat, new IntPtr(pixels));
    					buffer.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
    					buffer.Graphics.DrawImage(bitmap, bounds);
    					buffer.Render();
    				}
    			}
    			else
    			{
    				if (mode == RenderMode.PreallocatedBitmap)
    				{
    					fixed (int* pixels = &this.pixels[0, 0])
    					{
    						info.Scan0 = new IntPtr(pixels); info.Reserved = 0;
    						bitmap.LockBits(area, ImageLockMode.WriteOnly | ImageLockMode.UserInputBuffer, info.PixelFormat, info);
    						bitmap.UnlockBits(info);
    					}
    					buffer.Graphics.DrawImage(bitmap, canvas.DisplayRectangle);
    				}
    				buffer.Render();
    			}
    		}
    	}
    	class Game
    	{
    		[STAThread]
    		public static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			var game = new Game();
    			game.Run();
    		}
    		Form form;
    		Control canvas;
    		Screen screen;
    		Level level;
    		Player player;
    		private Game()
    		{
    			form = new Form();
    			canvas = new Control { Parent = form, Bounds = new Rectangle(0, 0, 900, 506) };
    			form.ClientSize = canvas.Size;
    			screen = new Screen(canvas, new Size(300, 160));
    			level = new Level { game = this };
    			player = new Player { game = this };
    		}
    		private void Run()
    		{
    			bool toggleModeRequest = false;
    			canvas.MouseClick += (sender, e) => toggleModeRequest = true;
    			var worker = new Thread(() =>
    			{
    				int frameCount = 0;
    				Stopwatch drawT = new Stopwatch(), applyT = new Stopwatch(), advanceT = Stopwatch.StartNew(), renderT = Stopwatch.StartNew(), infoT = Stopwatch.StartNew();
    				while (true)
    				{
    					if (advanceT.ElapsedMilliseconds >= 3)
    					{
    						level.Advance(); player.Advance();
    						advanceT.Restart();
    					}
    					if (renderT.ElapsedMilliseconds >= 8)
    					{
    						frameCount++;
    						drawT.Start(); level.Render(); player.Render(); drawT.Stop();
    						applyT.Start(); screen.Render(); applyT.Stop();
    						renderT.Restart();
    					}
    					if (infoT.ElapsedMilliseconds >= 1000)
    					{
    						double drawS = drawT.ElapsedMilliseconds / 1000.0, applyS = applyT.ElapsedMilliseconds / 1000.0, totalS = drawS + applyS;
    						var info = string.Format("Render using {0} - Frames:{1:n0} FPS:{2:n0} Draw:{3:p2} Apply:{4:p2}",
    							screen.mode, frameCount, frameCount / totalS, drawS / totalS, applyS / totalS);
    						form.BeginInvoke(new Action(() => form.Text = info));
    						infoT.Restart();
    					}
    					if (toggleModeRequest)
    					{
    						toggleModeRequest = false;
    						screen.mode = (RenderMode)(((int)screen.mode + 1) % 3);
    						screen.ApplyMode();
    						frameCount = 0; drawT.Reset(); applyT.Reset();
    					}
    				}
    			});
    			worker.IsBackground = true;
    			worker.Start();
    			Application.Run(form);
    		}
    		class Level
    		{
    			public Game game;
    			public int pos = 0; bool right = true;
    			public void Advance() { Game.Advance(ref pos, ref right, 0, game.screen.area.Right - 1); }
    			public void Render()
    			{
    				game.screen.FillRectangle(Color.SaddleBrown, new Rectangle(0, 0, pos, game.screen.area.Height));
    				game.screen.FillRectangle(Color.DarkGreen, new Rectangle(pos, 0, game.screen.area.Right, game.screen.area.Height));
    			}
    		}
    		class Player
    		{
    			public Game game;
    			public int x = 0, y = 0;
    			public bool right = true, down = true;
    			public void Advance()
    			{
    				Game.Advance(ref x, ref right, game.level.pos, game.screen.area.Right - 5, 2);
    				Game.Advance(ref y, ref down, 0, game.screen.area.Bottom - 1, 2);
    			}
    			public void Render() { game.screen.FillRectangle(Color.Yellow, new Rectangle(x, y, 4, 4)); }
    		}
    		static void Advance(ref int pos, ref bool forward, int minPos, int maxPos, int delta = 1)
    		{
    			if (forward) { pos += delta; if (pos < minPos) pos = minPos; else if (pos > maxPos) { pos = maxPos; forward = false; } }
    			else { pos -= delta; if (pos > maxPos) pos = maxPos; else if (pos < minPos) { pos = minPos; forward = true; } }
    		}
    	}
    }
