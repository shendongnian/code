    using System;
    using System.Drawing;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Colors
    {
        public partial class Form1 : Form
        {
            Random rand = new Random();
    
            Color[] colors = new Color[5] {
                Color.Orange,
                Color.Red,
                Color.Pink,
                Color.Black,
                Color.Gold
            };
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == (char)Keys.R)
                {
                    var color = colors[rand.Next(0, colors.Length)];
                    var graphics = CreateGraphics();
    
                    Task.Factory.StartNew(() =>
                    {
                        using (var pen = new Pen(color, 3))
                            for (int i = 0; i < 100; i++)
                            {
                                graphics.DrawRectangle(pen, 
                                    new Rectangle(
                                        rand.Next(0, Width), 
                                        rand.Next(0, Height), 10, 10));
                                Thread.Sleep(100);
                            }
                    });
                }
            }
        }
    }
