    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace Colors
    {
        public partial class Form1 : Form
        {
            Timer timer = new Timer { Interval = 100 };
            Random rand = new Random();
            Color[] colors = new Color[5]
            {
                Color.Black,
                Color.Blue,
                Color.Green,
                Color.Purple,
                Color.Red
            };
    
            List<Pen> usedPens = new List<Pen>();
            List<Rectangle> usedRectangles = new List<Rectangle>();
    
            Pen penToUse;
            List<Rectangle> rectanglesToUse = new List<Rectangle>();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            protected override void OnKeyPress(KeyPressEventArgs e)
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    penToUse = new Pen(GetRandomColor(), 3);
    
                    rectanglesToUse.Clear();
                    for (int i = 0; i < 100; i++)
                        rectanglesToUse.Add(GetRandomRectangle());
    
                    this.Refresh();
                }
            }
    
            private Color GetRandomColor()
            {
                return colors[rand.Next(0, colors.Length)];
            }
    
            private Rectangle GetRandomRectangle()
            {
                return new Rectangle(rand.Next(0, Width), rand.Next(0, Height), 10, 10);
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
                for (int i = 0; i < usedRectangles.Count; i++)
                    e.Graphics.DrawRectangle(usedPens[i % 100], usedRectangles[i]);
    
                timer.Tick += delegate
                {
                    if (rectanglesToUse.Count > 0)
                    {
                        e.Graphics.DrawRectangle(penToUse, rectanglesToUse[0]);
                        usedRectangles.Add(rectanglesToUse[0]);
                        rectanglesToUse.RemoveAt(0);
                    }
                    else
                    {
                        usedPens.Add(penToUse);
                        timer.Stop();
                    }
                };
                timer.Start();
            }
        }
    }
