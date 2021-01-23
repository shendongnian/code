    using DataProcessing;  // no console-stuff
    using Microsoft.Win32;
    class WinFormsApp : Forms
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            var r = new Retriever();
            var data = r.GetData();
            foreach(var in in data)
            {
                myLabel.Text += i;
            }
        }
    }
