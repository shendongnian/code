    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WinForm
    {
        public partial class frmMain : Form
        {
            /// <summary>
            /// form constructor
            /// </summary>
            public frmMain()
            {
                InitializeComponent();
            }
    
            private PictureBox imgCanvas;
            private bool isMouseDown;
            private Point startPoint;
            private Point currentPoint;
    
            /// <summary>
            /// form load
            /// </summary>
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
    
                imgCanvas = new PictureBox
                {
                    Location = new Point(8, 8),
                    Size = new Size(this.ClientSize.Width - 16, this.ClientSize.Height - 16),
                    Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom,
                    BorderStyle = BorderStyle.Fixed3D,
                };
                imgCanvas.MouseDown += imgCanvas_MouseDown;
                imgCanvas.MouseUp += imgCanvas_MouseUp;
                imgCanvas.MouseMove += imgCanvas_MouseMove;
                imgCanvas.Paint += imgCanvas_Paint;
                this.Controls.Add(imgCanvas);
            }
    
            void imgCanvas_Paint(object sender, PaintEventArgs e)
            {
                if (isMouseDown)
                {
                    e.Graphics.DrawLine(Pens.Red, startPoint, currentPoint);
                }
            }
    
            void imgCanvas_MouseMove(object sender, MouseEventArgs e)
            {
                if (isMouseDown)
                {
                    currentPoint = e.Location;
                    (sender as PictureBox).Refresh();
                }
            }
    
            void imgCanvas_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    isMouseDown = true;
                    startPoint = e.Location;
                }
            }
    
            void imgCanvas_MouseUp(object sender, MouseEventArgs e)
            {
                if (isMouseDown)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        isMouseDown = false;
    
                        PictureBox pb = sender as PictureBox;
    
                        // create image
                        if (pb.Image == null)
                        {
                            pb.Image = new Bitmap(pb.ClientSize.Width, pb.ClientSize.Height);
                        }
    
                        // draw
                        using (Graphics g = Graphics.FromImage(pb.Image))
                        {
                            g.DrawLine(Pens.Green, startPoint, e.Location);
                            pb.Refresh();
                        }
                    }
                }
            }
        }
    }
