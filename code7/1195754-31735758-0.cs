    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Diagnostics;
    
    namespace PictureClicker
    {
    	/// <summary>
    	/// Description of MainForm.
    	/// </summary>
    	public partial class MainForm : Form
    	{
    		Bitmap dartboard;
    		Bitmap scoreboard;
    		
    		public MainForm()
    		{
    			//
    			// The InitializeComponent() call is required for Windows Forms designer support.
    			//
    			InitializeComponent();
    			
    			//
    			// TODO: Add constructor code after the InitializeComponent() call.
    			//
    			dartboard = new Bitmap("dartboard.bmp");
    			scoreboard = new Bitmap("scoreboard.bmp");
    		}
    		void MainFormPaint(object sender, PaintEventArgs e)
    		{
    			e.Graphics.DrawImage(dartboard, 0, 0);
    		}
    		void MainFormMouseUp(object sender, MouseEventArgs e)
    		{
    			int score = scoreboard.GetPixel(e.X, e.Y).ToArgb(); // Convert pixel to 32-bit representation to facilitate comparison
    			
    			// Lookup table
    			if (score == Color.Red.ToArgb()) RecordScore(16); // Red FF0000
    			else if (score == Color.Lime.ToArgb()) RecordScore(8); // Green 00FF00
    			else if (score == Color.Blue.ToArgb()) RecordScore(4); // Blue 0000FF
    			else if (score == Color.Yellow.ToArgb()) RecordScore(2); // Yellow FFFF00
    			else if (score == Color.Magenta.ToArgb()) RecordScore(1); // Purple (Magenta) FF00FF
    			else if (score == Color.Cyan.ToArgb()) RecordScore(100); // Cyan 00FFFF
    			else
    				Debug.WriteLine("Unknown Score");
    		}
    		
    		void RecordScore(int _score)
    		{
    			Debug.WriteLine("Hit: " + _score.ToString());
    		}
    	}
    }
