	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
	using System.Threading;
	using System.Threading.Tasks;
	namespace ProgressBar
	{
		public partial class Form1 : Form
		{
			readonly SynchronizationContext _synchronizationContext = null;
				
			public Form1()
			{
				InitializeComponent();
				_synchronizationContext = SynchronizationContext.Current;
			}
			private void btnDoWork_Click(object sender, EventArgs e)
			{
				Task task1 = new Task(() => { System.Threading.Thread.Sleep(5000); });
				Task task2 = new Task(() => { System.Threading.Thread.Sleep(5000); });
				Task task3 = new Task(() => { System.Threading.Thread.Sleep(5000); });
				Task task4 = new Task(() => { System.Threading.Thread.Sleep(5000); });
				task1.ContinueWith((t) =>
				{
					if (t.Exception != null)
						t.Exception.Handle(ex =>
						{
							//do something
							return true;
						});
					progressBar.Value = 25;
				}, TaskScheduler.FromCurrentSynchronizationContext()).ContinueWith((t) => task2.Start());
			   
				task2.ContinueWith((t) =>
				{
					if (t.Exception != null)
						t.Exception.Handle(ex =>
						{
							//do something
							return true;
						});
					progressBar.Value = 50;
				}, TaskScheduler.FromCurrentSynchronizationContext()).ContinueWith((t) => task3.Start());
				task3.ContinueWith((t) =>
				{
					if (t.Exception != null)
						t.Exception.Handle(ex =>
						{
							//do something
							return true;
						});
					progressBar.Value = 75;
				}, TaskScheduler.FromCurrentSynchronizationContext()).ContinueWith((t) => task4.Start());
				task4.ContinueWith((t) =>
				{
					if (t.Exception != null)
						t.Exception.Handle(ex =>
						{
							//do something
							return true;
						});
					progressBar.Value = 100;
				}, TaskScheduler.FromCurrentSynchronizationContext());
				task1.Start();
			}
		}
	}
