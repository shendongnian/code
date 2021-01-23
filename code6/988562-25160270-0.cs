    using System;
    using System.IO;
    using System.Drawing;
    using System.Windows.Forms;
    namespace ProgramTestDrawLine
    {
        class Main_Window : Form
        {
            Point a;
            Point b;
            public Main_Window()
            {
                this.Width = 500;
                this.Height = 500;
                this.Paint += Main_Window_Paint;
            }
            void Main_Window_Paint(object sender, EventArgs e)
            {
                StreamReader sr = new StreamReader("points.txt");
                string fileContents = sr.ReadLine();
                sr.Close();
                string[] points = fileContents.Split(',');
                Point a = new Point(int.Parse(points[0]), int.Parse(points[1]));
                Point b = new Point(int.Parse(points[2]), int.Parse(points[3]));
                Graphics g = this.CreateGraphics();
                g.DrawLine(new Pen(Brushes.Black,2),a, b);
            }
        }
        class Main_W
        {
            static void Main()
            {
                Main_Window form = new Main_Window();
                Application.EnableVisualStyles();
                Application.Run(form);
            }
        }
    }
