	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Data;
	using System.Diagnostics;
    public partial class Form1 : Form
	{
		private System.Windows.Forms.Timer tmrClick = new System.Windows.Forms.Timer();
		private System.Windows.Forms.Timer tmrWait = new System.Windows.Forms.Timer();
		public Form1()
		{
			InitializeComponent();
			tmrClick.Interval = 2000;
			tmrClick.Enabled = true;
			tmrClick.Tick += tmrClick_Tick;
			tmrWait.Interval = 2000; //SLEEP_AFTER_CLICK_PAGE
			tmrWait.Enabled = false;
			tmrWait.Tick += tmrWait_Tick;
		}
		private void tmrClick_Tick(object sender, EventArgs e)
		{
			label1.Text = "CLICK";
			tmrClick.Stop();
			tmrWait.Start();
		}
		private void tmrWait_Tick(object sender, EventArgs e)
		{
			label1.Text = "WAIT DONE";
			tmrWait.Stop();
			tmrClick.Start();
		}
	}
