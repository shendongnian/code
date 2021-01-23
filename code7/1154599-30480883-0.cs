    using System;
    using System.Threading;
    using System.Windows.Forms;
    
    public class NonModalMessageBox : IWin32Window {
        public NonModalMessageBox(Form owner, Action<IWin32Window> display) {
            this.handle = owner.Handle;
            var t = new Thread(new ThreadStart(() => display(this)));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        public IntPtr Handle {
            get { return handle; }
        }
        private IntPtr handle;
    }
