    using System;
    using System.Windows.Forms;
    
    namespace TestForm
    {
        public partial class Form1 : Form
        {
            FakeAsync test = new FakeAsync();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                test.Start();
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                test.IsSet = true;
            }
        }
    
        public class FakeAsync
        {
            public bool Running { get; protected set; }
            public bool IsSet { get; set; }
    
            protected virtual void Loop()
            {
                Running = true;
                while (!IsSet)
                {
                    Application.DoEvents();
                }
                MessageBox.Show("Hello World!");
                Running = false;
            }
    
            public void Start()
            {
                if (!Running)
                {
                    Loop();
                }
            }
        }
    }
