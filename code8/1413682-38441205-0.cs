    public partial class mainForm : Form
    {
        private const string HOST_1 = "192.168.0.30";
        private const string HOST_2 = "192.168.0.31";
        private string SendCommand(string host, string Command)
        {
            //code that uses Hostname to toggle switch, which does work
            // Just use host here
        }
        private void btnProgramEther_Click_1(object sender, EventArgs e)
        {
            SendCommand(HOST_1, "turn switch on");
        }
    }
