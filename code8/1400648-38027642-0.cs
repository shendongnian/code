    public partial class Form1 : Form
    {
        public Form1()
        {
            //InitializeComponent();
            pictureBox1 = new PictureBox { Parent = this, Dock = DockStyle.Fill };
            ants.Add(new Ant { Role = AntRole.Scout, Position = new Point(50, 50) });
            ants.Add(new Ant { Role = AntRole.Scout, Position = new Point(150, 150) });
            ants.Add(new Ant { Role = AntRole.Scout, Position = new Point(100, 100) });
            pictureBox1.Paint += RenderAnts;
            pictureBox1.Click += (s, e) =>
            {
                for (int i = 0; i < 100; i++)
                    foreach (Ant a in ants)
                    {
                        if (a.Role == AntRole.Scout)
                        {
                            a.Move();
                            antTrails.Add(a.Position);
                        }
                    }
                pictureBox1.Refresh();
            };
        }
        PictureBox pictureBox1;
        List<Ant> ants = new List<Ant>();
        List<Point> antTrails = new List<Point>();
        public void RenderAnts(object sender, PaintEventArgs e)
        {
            foreach (var point in antTrails)
                e.Graphics.FillRectangle(Brushes.Red, point.X, point.Y, 1, 1);
        }
    }
    public class Ant
    {
        public AntRole Role;
        public Point Position;
        static Random rnd = new Random();
        public void Move()
        {
            int r = rnd.Next(4);
            if (r == 0)
                Position.X--;
            else if (r == 1)
                Position.X++;
            else if (r == 2)
                Position.Y--;
            else
                Position.Y++;
        }
    }
    public enum AntRole
    {
        Normal,
        Scout
    }
