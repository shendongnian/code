     namespace DEMO_Apps
    {
        public partial class MainForm : Form
        {
            int xpos;
            int ypos;
            public MainForm()
            {
                InitializeComponent();
            }
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                var o = Utility.GetCaretPoint(textBox1);
                xpos = o.X;
                ypos = o.Y;
                textBox2.Text = Convert.ToString(xpos + "," +  ypos);                
            }     
        }
    
        public static class Utility
        {
            ///for System.Windows.Forms.TextBox
            public static System.Drawing.Point GetCaretPoint(System.Windows.Forms.TextBox textBox)
            {
                int start = textBox.SelectionStart;
                if (start == textBox.TextLength)
                start --;
                return textBox.GetPositionFromCharIndex(start);
            }
    
            ///for System.Windows.Controls.TextBox requires reference to the following dlls: PresentationFramework, PresentationCore & WindowBase.
            //So if not using those dlls you should comment the code below:
            
            public static System.Windows.Point GetCaretPoint(System.Windows.Controls.TextBox textBox)
            {
                return textBox.GetRectFromCharacterIndex(textBox.SelectionStart).Location;
            }
        }
    }
