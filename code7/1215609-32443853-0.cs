    using MinimalisticTelnet;
    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    namespace Telnet
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private MinimalisticTelnet.TelnetConnection _tc;
            private void Form1_Load(object sender, EventArgs e)
            {
                _tc = new TelnetConnection("telehack.com", 23);
            }
            private void timer1_Tick(object sender, EventArgs e)
            {
                ProcessOutput();
            }
            private void btnSendCommand_Click(object sender, EventArgs e)
            {
                if (_tc.IsConnected)
                {
                    _tc.WriteLine(tbCommand.Text.Trim());
                    tbCommand.Clear();
                    tbCommand.Focus();
                    ProcessOutput();
                }
            }
            private void ProcessOutput()
            {
                if (!_tc.IsConnected)
                    return;
                var s = _tc.Read();
                s = Regex.Replace(s, @"\x1b\[([0-9,A-Z]{1,2}(;[0-9]{1,2})?(;[0-9]{3})?)?[m|K]?", "");
                tbOutput.AppendText(s);
            }
        }
    }
