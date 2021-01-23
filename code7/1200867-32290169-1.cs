    namespace UI
    {
    	using System;
    	using System.Collections.Generic;
    	using System.Drawing;
    	using System.Windows.Forms;
    	using POCOs;
    
    	class TestForm : Form
    	{
    		public TestForm()
    		{
    			var items = new List<Appliance>
    			{
    				new Appliance { Name = "A1", Top = 20, Left = 40, Width = 30, Height = 30, Color = Color.Red.ToArgb(), Visible = true },
    				new Appliance { Name = "A2", Top = 100, Left = 20, Width = 80, Height = 20, Color = Color.Blue.ToArgb(), Visible = true },
    				new Appliance { Name = "A3", Top = 60, Left = 40, Width = 50, Height = 30, Color = Color.Green.ToArgb(), Visible = true },
    			};
    			foreach (var item in items)
    			{
    				var presenter = new PictureBox { Name = item.Name, Tag = item };
    				presenter.DataBindings.Add("Left", item, "Left");
    				presenter.DataBindings.Add("Top", item, "Top");
    				presenter.DataBindings.Add("Width", item, "Width");
    				presenter.DataBindings.Add("Height", item, "Height");
    				presenter.DataBindings.Add("Visible", item, "Visible");
    				var binding = presenter.DataBindings.Add("BackColor", item, "Color");
    				binding.Format += (_sender, _e) => _e.Value = Color.FromArgb((int)_e.Value);
    				presenter.Click += OnPresenterClick;
    				Controls.Add(presenter);
    			}
    			// Test. Note we are working only with POCOs
    			var random = new Random();
    			var timer = new Timer { Interval = 200, Enabled = true };
    			timer.Tick += (_sender, _e) =>
    			{
    				int i = random.Next(items.Count);
    				int left = items[i].Left + 16;
    				if (left + items[i].Width > DisplayRectangle.Right) left = 0;
    				items[i].Left = left;
    			};
    		}
    
    		private void OnPresenterClick(object sender, EventArgs e)
    		{
    			// We are getting POCO from the control tag
    			var item = (Appliance)((Control)sender).Tag;
    			item.Color = Color.Yellow.ToArgb();
    		}
    
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			Application.Run(new TestForm());
    		}
    	}
    }
