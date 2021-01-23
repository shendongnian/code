    using System;
    using System.Threading;
    using System.Windows.Forms;
    
    class ActiveXHost : Form {
        public ActiveXHost(Control control, bool hidden = false) {
            if (control.IsHandleCreated) throw new InvalidOperationException("Control already committed to wrong thread");
            if (hidden) this.Opacity = 0;
            this.ShowInTaskbar = false;
    
            using (initDone = new ManualResetEvent(false)) {
                thread = new Thread((_) => {
                    this.Controls.Add(control);
                    Application.Run(this);
                });
                thread.IsBackground = true;
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                initDone.WaitOne();
            }
        }
        public void Execute(Action action) {
            this.BeginInvoke(action);
        }
        public TResult Execute<TResult>(Func<TResult> action) {
            return (TResult)this.Invoke(action);
        }
    
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            initDone.Set();
        }
        protected override void Dispose(bool disposing) {
            if (disposing && thread != null) {
               this.Invoke(new Action(() => {
                   base.Dispose(disposing);
                   Application.ExitThread();
                   thread = null;
               }));
            }
        }
    
        private Thread thread;
        private ManualResetEvent initDone;
    }
