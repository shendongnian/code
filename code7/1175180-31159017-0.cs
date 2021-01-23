    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace ShapeDrawing
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            public abstract class SHAPE
            {
                public Pen MyPen = new Pen(Color.Brown, 3.5F);
                public abstract void getparameters();
                public abstract void drawshape(Form1 e);
                public abstract void description(Form1 e);
                public void enabling(Form1 e) 
                {
                    e.RetryButton.Enabled = true;
                    e.ExitButton.Enabled = true;
                }
            }
    
            public class LINE : SHAPE
            {
                float x1,x2,y1,y2;
                public override void getparameters()
                {
                    PopForLine Popup = new PopForLine();
                    DialogResult dialogresult = Popup.ShowDialog();
                    if (dialogresult==DialogResult.OK)
                    {
                        try
                        {
                            this.x1 = (float)Convert.ToDouble(Popup.Point1XText.Text);
                            this.y1 = (float)Convert.ToDouble(Popup.Point1YText.Text);
                            this.x2 = (float)Convert.ToDouble(Popup.Point2XText.Text);
                            this.y2 = (float)Convert.ToDouble(Popup.Point2YText.Text);
                        }
                        catch(Exception e) 
                        {
                            x1=x2=y1=y2=0;
                        }
                    }
                    Popup.Dispose();
                }
                public override void drawshape(Form1 e) 
                {
                    Graphics formGraphics = e.ShapeSpace.CreateGraphics();
                    formGraphics.DrawLine(MyPen,x1,y1,x2,y2);
                    formGraphics.Dispose();
                }
    
                public override void description(Form1 e) 
                {
                    double linelength;
                    linelength = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
                    e.Description.Text = "This is a line of length " + Convert.ToString(linelength) + " starting from (" + Convert.ToString(x1) + "," + Convert.ToString(y1) + ") to (" + Convert.ToString(x2) + " , " + Convert.ToString(y2)+") .\n";
                }
            }
    
            class RECTANGLE : SHAPE
            {
                float Length, Breadth;
                public override void getparameters()
                {
                    PopForRect Popup = new PopForRect();
                    DialogResult dialogresult = Popup.ShowDialog();
                    if (dialogresult == DialogResult.OK)
                    {
                        try
                        {
                            Length = (float)Convert.ToDouble(Popup.LengthText.Text);
                            Breadth =(float) Convert.ToDouble(Popup.BreadthText.Text);
                        }
                        catch (Exception e) 
                        {
                            Length = 0;
                            Breadth = 0;
                        }
                    }
                    Popup.Dispose();
                }
                public override void drawshape(Form1 e)
                {
                    Graphics formGraphics = e.ShapeSpace.CreateGraphics();
                    formGraphics.DrawRectangle(MyPen, 0, 0, Length,Breadth);
                    formGraphics.Dispose();            
                }
    
                public override void description(Form1 e)
                {
                    e.Description.Text = "This is a rectangle of width= " + Convert.ToString(Length) + " and height= " + Convert.ToString(Breadth) + " .\n";
                }
            }
    
            class ELLIPSE : SHAPE
            {
                float radius1, radius2;
                public override void getparameters()
                {
                    PopForEllipse Popup = new PopForEllipse();
                    DialogResult dialogresult = Popup.ShowDialog();
                    if (dialogresult == DialogResult.OK)
                    {
                        try
                        {
                            this.radius1 = (float)Convert.ToDouble(Popup.SRadText.Text);
                            this.radius2 = (float)Convert.ToDouble(Popup.LRadText.Text);
                        }
                        catch (Exception e)
                        {
                            radius1 = 0;
                            radius2 = 0;
                        }
                    }
                    Popup.Dispose();
                }
                public override void drawshape(Form1 e)
                {
                    Graphics formGraphics = e.ShapeSpace.CreateGraphics();
                    formGraphics.DrawEllipse(MyPen, 0, 0, radius1, radius2);
                    formGraphics.Dispose();
                }
    
                public override void description(Form1 e)
                {
                    e.Description.Text = "This is an ellipse of width= " + Convert.ToString(radius2) + " and height= " + Convert.ToString(radius1) + " .\n";
                }
            }
    
            private void LineButton_Click(object sender, EventArgs e)
            {
                LINE MyLine = new LINE();
                MyLine.getparameters();
                MyLine.drawshape(this);
                MyLine.MyPen.Dispose();
                MyLine.description(this);
                MyLine.enabling(this);
            }
    
            private void EllipseButton_Click(object sender, EventArgs e)
            {
                ELLIPSE MyEllipse = new ELLIPSE();
                MyEllipse.getparameters();
                MyEllipse.drawshape(this);
                MyEllipse.MyPen.Dispose();
                MyEllipse.description(this);
                MyEllipse.enabling(this);
            }
    
            private void RectButton_Click(object sender, EventArgs e)
            {
                RECTANGLE MyRectangle = new RECTANGLE();
                MyRectangle.getparameters();
                MyRectangle.drawshape(this);
                MyRectangle.MyPen.Dispose();
                MyRectangle.description(this);
                MyRectangle.enabling(this);
            }
    
            private void ExitButton_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }
    
            private void RetryButton_Click(object sender, EventArgs e)
            {
                Description.Text = " ";
                ShapeSpace.Image = null;
            }
        }
    
    }
