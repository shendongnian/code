    using System;
    using System.Drawing;
    using System.Windows.Forms;
    namespace Custom_Title_Bar
    {
	public partial class MainForm : Form
	{
		private PictureBox title = new PictureBox(); // create a PictureBox
		private Label minimise = new Label(); // this doesn't even have to be a label!
		private Label maximise = new Label(); // this will simulate our this.maximise box
		private Label close = new Label(); // simulates the this.close box
		
		private bool drag = false; // determine if we should be moving the form
		private Point startPoint = new Point(0, 0); // also for the moving
		
		public MainForm()
		{
			this.FormBorderStyle = FormBorderStyle.None; // get rid of the standard title bar
			
			this.title.Location = this.Location; // assign the location to the form location
			this.title.Width = this.Width; // make it the same width as the form
			this.title.Height = 50; // give it a default height (you may want it taller/shorter)
			this.title.BackColor = Color.Black; // give it a default colour (or load an image)
			this.Controls.Add(this.title); // add it to the form's controls, so it gets displayed
			// if you have an image to display, you can load it, instead of assigning a bg colour
			// this.title.Image = new Bitmap(System.Environment.CurrentDirectory + "\\title.jpg");
			// if you displayed an image, alter the SizeMode to get it to display as you want it to
			// examples:
			// this.title.SizeMode = PictureBoxSizeMode.StretchImage;
			// this.title.SizeMode = PictureBoxSizeMode.CenterImage;
			// this.title.SizeMode = PictureBoxSizeMode.Zoom;
			// etc			
			
			// you may want to use PictureBoxes and display images
			// or use buttons, there are many alternatives. This is a mere example.
			this.minimise.Text = "Minimise"; // Doesn't have to be
			this.minimise.Location = new Point(this.Location.X+5, this.Location.Y+5); // give it a default location
			this.minimise.ForeColor = Color.Red; // Give it a colour that will make it stand out
			// this is why I didn't use an image, just to keep things simple:
			this.minimise.BackColor = Color.Black; // make it the same as the PictureBox
			this.Controls.Add(this.minimise); // add it to the form's controls
			this.minimise.BringToFront(); // bring it to the front, to display it above the picture box
			
			this.maximise.Text = "Maximise";
			// remember to make sure it's far enough away so as not to overlap our minimise option
			this.maximise.Location = new Point(this.Location.X+60, this.Location.Y+5);
			this.maximise.ForeColor = Color.Red;
			this.maximise.BackColor = Color.Black; // remember, we want it to match the background
			this.maximise.Width = 50;
			this.Controls.Add(this.maximise); // add it to the form
			this.maximise.BringToFront();
			
			this.close.Text = "Close";
			this.close.Location = new Point(this.Location.X+120, this.Location.Y+5);
			this.close.ForeColor = Color.Red;
			this.close.BackColor = Color.Black;
			this.close.Width = 37; // this is just to make it fit nicely
			this.Controls.Add(this.close);
			this.close.BringToFront();
			
			// now we need to add some functionality. First off, let's give those labels
			// MouseHover and MouseLeave events, so they change colour
			// Since they're all going to change to the same colour, we can give them the same
			// event handler, which saves time of writing out all those extra functions
			this.minimise.MouseEnter += new EventHandler(Control_MouseEnter);
			this.maximise.MouseEnter += new EventHandler(Control_MouseEnter);
			this.close.MouseEnter += new EventHandler(Control_MouseEnter);
			
			// and we need to do the same for MouseLeave events, to change it back
			this.minimise.MouseLeave += new EventHandler(Control_MouseLeave);
			this.maximise.MouseLeave += new EventHandler(Control_MouseLeave);
			this.close.MouseLeave += new EventHandler(Control_MouseLeave);
			
			// and lastly, for these controls, we need to add some functionality
			this.minimise.MouseClick += new MouseEventHandler(Control_MouseClick);
			this.maximise.MouseClick += new MouseEventHandler(Control_MouseClick);
			this.close.MouseClick += new MouseEventHandler(Control_MouseClick);
			
			// finally, wouldn't it be nice to get some moveability on this control?
			this.title.MouseDown += new MouseEventHandler(Title_MouseDown);
			this.title.MouseUp += new MouseEventHandler(Title_MouseUp);
			this.title.MouseMove += new MouseEventHandler(Title_MouseMove);			
		}
		
		private void Control_MouseEnter(object sender, EventArgs e)
		{
			if (sender.Equals(this.close))
				this.close.ForeColor = Color.White;
			else if (sender.Equals(this.maximise))
				this.maximise.ForeColor = Color.White;
			else // it's the minimise label
				this.minimise.ForeColor = Color.White;				
		}
		
		private void Control_MouseLeave(object sender, EventArgs e)
		{ // return them to their default colours
			if (sender.Equals(this.close))
				this.close.ForeColor = Color.Red;
			else if (sender.Equals(this.maximise))
				this.maximise.ForeColor = Color.Red;
			else // it's the minimise label
				this.minimise.ForeColor = Color.Red;	
		}
		
		private void Control_MouseClick(object sender, MouseEventArgs e)
		{
			if (sender.Equals(this.close))
				this.Close(); // close the form
			else if (sender.Equals(this.maximise))
			{ // maximise is more interesting. We need to give it different functionality,
			  // depending on the window state (Maximise/Restore)
			  	if (this.maximise.Text == "Maximise")
			  	{
					this.WindowState = FormWindowState.Maximized; // maximise the form
					this.maximise.Text = "Restore"; // change the text
					this.title.Width = this.Width; // stretch the title bar
			  	}
			  	else // we need to restore
			  	{ 
			  		this.WindowState = FormWindowState.Normal;
			  		this.maximise.Text = "Maximise";
			  	}
			}
			else // it's the minimise label
				this.WindowState = FormWindowState.Minimized; // minimise the form
		}
		
		void Title_MouseUp(object sender, MouseEventArgs e)
		{
			this.drag = false;
		}
		void Title_MouseDown(object sender, MouseEventArgs e)
		{
			this.startPoint = e.Location;
			this.drag = true;
		}
		void Title_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.drag) 
			{ // if we should be dragging it, we need to figure out some movement
				Point p1 = new Point(e.X, e.Y);
                Point p2 = this.PointToScreen(p1);
                Point p3 = new Point(p2.X - this.startPoint.X, 
                                     p2.Y - this.startPoint.Y);
                this.Location = p3;
			}
		}
	}   // end of the class
    }   // end of the namespace
