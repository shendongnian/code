    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
      public partial class Form1 : Form
      {
        private readonly Pen greenPen = new Pen(Brushes.Green);
        private readonly Pen redPen = new Pen(Brushes.Red);
        private readonly Font testFont = new Font(FontFamily.GenericSansSerif, 10f);
    
        public Form1()
        {
          InitializeComponent();
        }
    
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
          e.Graphics.DrawRectangle(redPen, 0f, 0f, 100f, 100f);
          e.Graphics.DrawEllipse(greenPen, 10f, 10f, 200f, 200f);
          e.Graphics.DrawString("Hello Graphics", testFont, Brushes.Blue, 30f, 30f);
        }
      }
    }
