    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace ControllerDemonstrator
    {
        public partial class Form1 : Form
        {
            public event EventHandler TestConnection;
    
            public Form1(Controller controller)
            {
                InitializeComponent();
                controller.CommunicatorDataLoaded += controller_CommunicatorDataLoaded;
            }
    
            void controller_CommunicatorDataLoaded(object sender, EventArgs e)
            {
                _testButton.Text = "Loaded";
            }
    
            private void _testButton_Click(object sender, EventArgs e)
            {
                if (null != TestConnection)
                {
                    TestConnection(this, new EventArgs());
                }
            }
        }
    }
