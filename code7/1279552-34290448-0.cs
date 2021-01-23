    using System;
    using System.Drawing;
    using System.Windows.Forms;
    namespace Samples
    {
    	static class Program
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			var text = "I want a box of a fixed size to show some text and have a link in it that is clickable in the bottom right corner for editing.";
    			int textSize = 50;
    			var form = new Form { Padding = new Padding(8) };
    			var panel = new Panel { Parent = form, BorderStyle = BorderStyle.FixedSingle, Padding = new Padding(4) };
    			var label = new Label { Dock = DockStyle.Fill, Parent = panel, AutoSize = false, Text = text, Height = textSize };
    			var link = new LinkLabel { Dock = DockStyle.Bottom, Parent = panel, AutoSize = false, TextAlign = ContentAlignment.MiddleRight, Text = "Edit" };
    			panel.Location = form.DisplayRectangle.Location;
    			panel.Width = form.DisplayRectangle.Width;
    			panel.Height = panel.Padding.Vertical + link.Height + label.Height;
    			Application.Run(form);
    		}
    	}
    }
