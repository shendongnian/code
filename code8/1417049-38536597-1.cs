    using System;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class ExampleProgram : Form
        {
            // global variables  
            string[] MyLines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\Test.txt"); // contain all lines
            int MyCurrentLine = 0;
    
            public ExampleProgram()
            {
                InitializeComponent();
                StartProgram(); // start the program
            }
    
            private void StartProgram()
            {
                timer1.Interval = 1000; // set interval in milliseconds
                timer1.Start(); // start timer
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                //timer1.Stop(); // first thing first - Edit: Looks like you did not need this.
                textBox1.Text = MyLines[MyCurrentLine % MyLines.Count()]; // display next line
                ++MyCurrentLine; // increment counter
                //timer1.Start(); // restart - Edit: And also won't need this. Less code.. Nice !
            }
        }
    }
