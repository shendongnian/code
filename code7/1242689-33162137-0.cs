    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace ControllerDemonstrator
    {
        public class Controller
        {
            public event EventHandler CommunicatorDataLoaded;
            public event EventHandler FormTestConnection;
    
            private Form1 _form;
            private Communicator _communicator;
    
            public Form1 MainForm
            {
                get { return _form; }
            }
    
            public Controller()
            {
                _form = new Form1(this);
                _form.TestConnection += _form_TestConnection;
                _form.FormClosed += _form_FormClosed;
                _communicator = new Communicator(this);
                _communicator.DataLoaded += _communicator_DataLoaded;
            }
    
            public void Start()
            {
                _form.Show();
            }
    
            void _form_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
            {
                //  put any code to clean up the communicator resources (if needed) here
                //  --------------------------------------------------------------------
                _communicator = null;
                //  Then exit
                //  ---------
                Application.Exit();
            }
    
            private void _communicator_DataLoaded(object sender, EventArgs e)
            {
                if (null != CommunicatorDataLoaded)
                {
                    CommunicatorDataLoaded(sender, e);
                }
            }
    
            private void _form_TestConnection(object sender, EventArgs e)
            {
                if (null != FormTestConnection)
                {
                    FormTestConnection(sender, e);
                }
            }
        }
    }
