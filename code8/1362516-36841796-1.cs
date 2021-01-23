    using System;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class AlertForm : Form
        {
            public CancellationTokenSource Cts { get; set; }
    
            public AlertForm()
            {
                InitializeComponent();
                Cts = new CancellationTokenSource();            
            }
    
            private void Cancel_Click(object sender, EventArgs e)
            {
                Cts.Cancel();
            }
        }
    }
