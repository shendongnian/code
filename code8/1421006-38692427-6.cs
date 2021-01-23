    namespace WindowsFormsApplication1
    {
       public partial class Form1 : Form
       {
           string javascript = @"<html><head><script type='text/javascript'>function gpsToAddress(param1, callback) {
        function CallbackA()
        {
            callback(param1);
        }
        setTimeout(function() { CallbackA() }, 1000);
     }</script></head></html>";
        public Form1()
        {
            InitializeComponent();
            webBrowser1.DocumentText = javascript;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Callback cb = new Callback();
            webBrowser1.Document.InvokeScript("gpsToAddress", new object[] { 123, cb });
        }
    }
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class Callback
    {
        // allows an instance of Callback to look like a function to the script
        // (allows callback() rather than forcing the script to do callback.callMe)
        [System.Runtime.InteropServices.DispId(0)]
        public void callMe(string v_address)
        {
            MessageBox.Show(v_address);
        }
    }
    }
