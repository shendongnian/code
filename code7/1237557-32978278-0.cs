    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace Tests
    {
    	static class Program
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			var form = new Form();
    			var panel = new Panel { Dock = DockStyle.Fill, Parent = form };
    			panel.AutoScroll = true;
    			// Setting the AutoScrollMinSize
    			int bitmapCount = 10;
    			int bitmapHeight = 200;
    			panel.AutoScrollMinSize = new Size(0, bitmapCount * bitmapHeight);
    			panel.Paint += (sender, e) =>
    			{
    				// Considering the AutoScrollPosition.Y
    				int offsetY = panel.AutoScrollPosition.Y;
                    var state = offsetY != 0 ? e.Graphics.Save() : null;
    				if (offsetY != 0) e.Graphics.TranslateTransform(0, offsetY);
    				var rect = new Rectangle(0, 0, panel.ClientSize.Width, bitmapHeight);
    				var sf = new StringFormat(StringFormat.GenericTypographic) { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    for (int i = 0; i < bitmapCount; i++)
    				{
    					// Your bitmap drawing goes here
    					e.Graphics.FillRectangle(Brushes.Yellow, rect);
    					e.Graphics.DrawRectangle(Pens.Red, rect);
    					e.Graphics.DrawString("Bitmap #" + (i + 1), panel.Font, Brushes.Blue, rect, sf);
    					rect.Y += bitmapHeight;
    				}
    				if (state != null) e.Graphics.Restore(state);
    			};
    			Application.Run(form);
    		}
    	}
    }
