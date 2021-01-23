		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Form f = new Form();
			var dp = new TimePicker("hh:mm:ss.f", true) { Location = new Point(100, 100) };
			dp.ByValue[2] = false;
			f.Controls.Add(dp);
			var bt1 = new Button { Text = "Now", Location = new Point(110, 130) };
			bt1.Click += delegate {
				dp.Value = DateTime.Now;
			};
			int k = 0;
			dp.ValueChanged += delegate {
				bt1.Text = "Now " + (k++);
			};
			f.Controls.Add(bt1);
			Application.Run(f);
		}
