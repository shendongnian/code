    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private Point OldPosition = new Point(0, 0);
            private Point ptSweetSpot = new Point(30, 30);
            private List<Point> sweetPointArea = new List<Point>() 
                { new Point(60, 60), new Point(60, 61), 
                  new Point(61, 60), new Point(61, 61)
                };
            
            public Form1()
            {
                InitializeComponent();
                pbFaseFlow.MouseMove += pbFaseFlow_MouseMove;
                Bitmap myBitmap = new Bitmap(pbFaseFlow.Height, pbFaseFlow.Width);
                myBitmap.SetPixel(ptSweetSpot.X, ptSweetSpot.Y, Color.Red);
                foreach (Point p in sweetPointArea)
                {
                   myBitmap.SetPixel(p.X, p.Y, Color.Green);
                }
                pbFaseFlow.Image = myBitmap;
            }
            private void pbFaseFlow_MouseMove(object sender, MouseEventArgs e)
            {
                if (!e.Location.Equals(OldPosition))
                {
                    OldPosition = e.Location;
    
                    // show the coords and tooltip text for debugging in some textbox
                    tbInfo.Text = e.X.ToString() + " " + e.Y.ToString();
    
                    //are we inside sweet area?
                    if (sweetPointArea.Contains(e.Location))
                    {
                        toolTip.Active = true;
                        toolTip.SetToolTip(pbFaseFlow, "hello from sweet area!");
                        toolTip.Show(toolTip.GetToolTip(pbFaseFlow), pbFaseFlow, pbFaseFlow.Width / 2, pbFaseFlow.Height / 2);
                    }
                    //no? so maybe we're over sweet spot?
                    else if (e.Location.Equals(ptSweetSpot)) 
                    {
                        toolTip.Active = true;
                        toolTip.SetToolTip(pbFaseFlow, "hello from sweet point!");
                        toolTip.Show(toolTip.GetToolTip(pbFaseFlow), pbFaseFlow, pbFaseFlow.Width / 2, pbFaseFlow.Height / 2);                }
                    //no? ok, so disable tooltip
                    else
                    {
                        toolTip.Active = false;
                    }
                }
            }
        }
    }
