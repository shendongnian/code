      public partial class Form1 : Form
      {
        private readonly Rectangle hitbox = new Rectangle(50, 50, 10, 10);
        private readonly Pen pen = new Pen(Brushes.Black);
    
        public Form1()
        {
          InitializeComponent();
        }
    
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
          e.Graphics.DrawRectangle(pen, hitbox);
        }
    
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
          if ((e.X > hitbox.X) && (e.X < hitbox.X + hitbox.Width) &&
              (e.Y > hitbox.Y) && (e.Y < hitbox.Y + hitbox.Height))
          {
            Text = "HIT";
          }
          else
          {
            Text = "NO";
          }
        }
      }
