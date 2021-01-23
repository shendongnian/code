    public partial class Form1 : Form
    {
        DrawingHelper dh;
        public Form1()
        {
            InitializeComponent();
            dh=new DrawingHelper(this);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            dh.Desser(this.CreateGraphics());
        }
    }
    public class DrawingHelper
    {
        Form form;
        public DrawingHelper(Form form)
        {
            this.form  =form;
        }
        public void Desser(Graphics Fg)
        {
            var pt=form.PointToClient(Form.MousePosition);
            Fg.DrawLine(Pens.Black, pt.X,pt.Y, pt.X+2, pt.Y+2);
        }
    }
