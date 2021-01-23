    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Autodraw
    {
        public partial class Form1 : Form
        {
            private bool canDraw;
    
            public class NPanel : Panel
            {
                protected override bool DoubleBuffered
                {
                    get
                    {
                        return base.DoubleBuffered;
                    }
    
                    set
                    {
                        base.DoubleBuffered = true;
                    }
                }
            }
    
            public NPanel nPanel = new NPanel();
    
            public Form1()
            {
                InitializeComponent();
    
                this.DoubleBuffered = true;
                panel = nPanel;
            }
    
            private void panel_Paint(object sender, PaintEventArgs e)
            {
                if (canDraw)
                {
                    for (int r = 0; r <= 255; r++)
                    {
                        e.Graphics.DrawRectangle(new Pen(Color.FromArgb(r, 0, 0), 1), r, r, r, r);
                    }
    
                    for (int r = 0; r <= 255; r++)
                    {
                        e.Graphics.DrawRectangle(new Pen(Color.FromArgb(0, r, 0), 1), r, r, r, r);
                    }
    
                    for (int r = 0; r <= 255; r++)
                    {
                        e.Graphics.DrawRectangle(new Pen(Color.FromArgb(0, 0, r), 1), r, r, r, r);
                    }
                }
            }
    
            private void timer_Tick(object sender, EventArgs e)
            {
                this.Refresh();
            }
    
            private void Form1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if(e.KeyChar == (char)Keys.Escape)
                {
                    timer.Stop();
                    canDraw = false;
                }
            }
    
            private void Form1_Shown(object sender, EventArgs e)
            {
                canDraw = true;
                timer.Start();
            }
        }
    }
