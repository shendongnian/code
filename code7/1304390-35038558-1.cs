	using System;
	using System.Threading;
	using System.Windows.Forms;
	using System.ComponentModel;
	namespace BgWorker
	{
		public partial class Form1 : Form
		{
			BackgroundWorker _bgWorker;
			bool _iNeedToCloseAfterBgWorker;
			public Form1()
			{
				InitializeComponent();
			}
			void Form1_Load(object sender, EventArgs e)
			{
				_bgWorker = new BackgroundWorker();
				_bgWorker.DoWork += _bgWorker_DoWork;
				_bgWorker.RunWorkerCompleted += _bgWorker_RunWorkerCompleted;
			}
			void _bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
			{
				MessageBox.Show("Done!");
				if (_iNeedToCloseAfterBgWorker)
					Close();
			}
			void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
			{
				// Do long lasting work
				Thread.Sleep(2000);
			}
			void btnWorkIt_Click(object sender, EventArgs e)
			{
				// Note how the Form remains accessible
				_bgWorker.RunWorkerAsync();
			}
			void Form1_FormClosing(object sender, FormClosingEventArgs e)
			{
				if (_iNeedToCloseAfterBgWorker || _bgWorker.IsBusy) return;
				e.Cancel = true;
				_iNeedToCloseAfterBgWorker = true;
				_bgWorker.RunWorkerAsync();
			}
		}
	}
