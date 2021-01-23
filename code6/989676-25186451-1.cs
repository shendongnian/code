    using System;
    using System.Reflection;
    [assembly:AssemblyVersion("1.1.0.0")] //Put the desired version number here.
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = typeof(Form1).Assembly.GetName().Version.ToString();
        }
    }
