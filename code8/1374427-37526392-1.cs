    using System;
    using System.Threading;
    using System.Windows.Forms;
    namespace CallBackFromCpp
    {
        public class Presenter
        {
            Form1 _view;
            WorkerClass _wc;
            public ApplicationContext Init()
            {
                _view = new Form1();
                _view.StartEvent += _view_StartEvent;
                _view.StopEvent += _view_StopEvent;
                return new ApplicationContext(_view);
            }
            void _view_StopEvent(object sender, EventArgs e)
            {
                if (_wc != null)
                    _wc.Stop = true;
            }
            delegate void ShowProgressDelegate(int progressPercentage, string message);
            private void ShowProgress(int progressPercentage, string message)
            {
                _view.richTextBox1.Text += String.Format("Report {0:00}% with message '{1}'\n", progressPercentage, message);
                _view.progressBar1.PerformStep();
            }
            void _view_StartEvent(object sender, EventArgs e)
            {
                ShowProgressDelegate showProgress = new ShowProgressDelegate(ShowProgress);
                _wc = new WorkerClass(_view, showProgress);
                Thread t = new Thread(new ThreadStart(_wc.RunProcess));
                t.IsBackground = true; //make them a daemon - prevent thread callback issues
                t.Start();
            }
       }
    }
