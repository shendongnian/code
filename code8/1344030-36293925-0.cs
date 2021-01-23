    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace Samples
    {
    	class Gadget
    	{
    		public readonly Control Canvas;
    
    		public Gadget(Control canvas) { Canvas = canvas; }
    
    		private Rectangle bounds;
    		public Rectangle Bounds
    		{
    			get { return bounds; }
    			set
    			{
    				if (bounds == value) return;
    				// NOTE: Invalidate both old and new rectangle
    				Invalidate();
    				bounds = value;
    				Invalidate();
    			}
    		}
    
    		private Color color;
    		public Color Color
    		{
    			get { return color; }
    			set
    			{
    				if (color == value) return;
    				color = value;
    				Invalidate();
    			}
    		}
    
    		public void Invalidate()
    		{
    			Canvas.Invalidate(bounds);
    		}
    
    		public void Draw(Graphics g)
    		{
    			using (var brush = new SolidBrush(color))
    				g.FillRectangle(brush, bounds);
    		}
    	}
    
    
    	static class Program
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    
    			var form = new Form { WindowState = FormWindowState.Maximized };
    			int rows = 9, cols = 9;
    			var gadgets = new Gadget[rows, cols];
    			var rg = new Random();
    			Color[] colors = { Color.Yellow, Color.Blue, Color.Red, Color.Green, Color.Magenta };
    			int size = 64;
    			var canvas = form;
    			for (int r = 0, y = 8; r < rows; r++, y += size)
    				for (int c = 0, x = 8; c < cols; c++, x += size)
    					gadgets[r, c] = new Gadget(canvas) { Color = colors[rg.Next(colors.Length)], Bounds = new Rectangle(x, y, size, size) };
    			int paintCount = 0, drawCount = 0;
    			canvas.Paint += (sender, e) =>
    			{
    				paintCount++;
    				for (int r = 0; r < rows; r++)
    				{
    					for (int c = 0; c < cols; c++)
    					{
    						if (e.ClipRectangle.IntersectsWith(gadgets[r, c].Bounds))
    						{
    							gadgets[r, c].Draw(e.Graphics);
    							drawCount++;
    						}
    					}
    				}
    				form.Text = $"Paint:{paintCount} Draw:{drawCount} of {(long)paintCount * rows * cols}";
    			};
    			var timer = new Timer { Interval = 100 };
    			timer.Tick += (sender, e) =>
    			{
    				gadgets[rg.Next(rows), rg.Next(cols)].Color = colors[rg.Next(colors.Length)];
    			};
    			timer.Start();
    
    
    			Application.Run(form);
    		}
    	}
    }
