    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Emgu.CV;
    using Emgu.CV.CvEnum;
    using Emgu.CV.Structure;
    using Emgu.CV.UI;
    namespace EmguCVShapeDetector
    {
    public partial class Form1 : Form
    {
        //---Variables--//
        
        bool blnFirstTimeInResizeEvent = true;
        int OriginalFormWidth;
        int OriginalFormHeight;
        int OriginalTableLayoutPanelWidth;
        int OriginalTableLayoutPanelHeight;
        
        Capture capwebcam;
        bool webCamCapturingInProcess = false;
        Image<Bgr, Byte> imgOriginal;
        Image<Bgr, Byte> imgSmoothed;
        Image<Gray, Byte> imgGrayColorFiltered;
        Image<Gray, Byte> imgCanny;
        Image<Bgr, Byte> imgCircles;
        Image<Bgr, Byte> imgLines;
        Image<Bgr, Byte> imgTrisRectsPolys;
        Double dbMinBlue = 0.0;
        double dbMinGreen = 0.0;
        double dbMinRed = 0.0;
        double dbMaxBlue = 0.0;
        double dbMaxGreen = 0.0;
        double dbMaxRed = 0.0;
        public Form1()
        {
            InitializeComponent();
            OriginalFormWidth = this.Width;
            OriginalFormHeight = this.Height;
            OriginalTableLayoutPanelWidth = tlpLebelsAndImageBoxes.Width;
            OriginalTableLayoutPanelHeight = tlpLebelsAndImageBoxes.Height;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 255; i++)
            {
                cmbMinBlue.Items.Add(i);
                cmbMinGreen.Items.Add(i);
                cmbMinRed.Items.Add(i);
                cmbMaxBlue.Items.Add(i+1);
                cmbMaxGreen.Items.Add(i+1);
                cmbMaxRed.Items.Add(i+1);
            }
            cmbMinBlue.Text = "0";
            cmbMinGreen.Text = "0";
            cmbMinRed.Text = "0";
            cmbMaxBlue.Text = "1";
            cmbMaxGreen.Text = "1";
            cmbMaxRed.Text = "1";
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if(blnFirstTimeInResizeEvent == true)
            {
                blnFirstTimeInResizeEvent = false;
            }
            else
            {
                tlpLebelsAndImageBoxes.Width = this.Width - (OriginalTableLayoutPanelWidth);
                tlpLebelsAndImageBoxes.Height = this.Height - (OriginalTableLayoutPanelHeight);
            }
        }
        private void radImageFile_CheckedChanged(object sender, EventArgs e)
        {
            if(radImageFile.Checked == true)
            {
                if(webCamCapturingInProcess == true)
                {
                    Application.Idle -= ProcessImageAndUpdateGUI;
                    webCamCapturingInProcess = false;
                }
                ibOriginal.Image = null;
                ibGrayColorFilter.Image = null;
                ibCanny.Image = null;
                ibCircles.Image = null;
                ibLines.Image = null;
                ibTrianglesAndPolys.Image = null;
                lblFile.Visible = true;
                txtFile.Visible = true;
                btnFile.Visible = true;
            }
        }
        private void radWebCam_CheckedChanged(object sender, EventArgs e)
        {
            if(radWebCam.Checked == true)
            {
                try
                {
                    capwebcam = new Capture();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                Application.Idle += ProcessImageAndUpdateGUI;
                webCamCapturingInProcess = true;
                lblFile.Visible = false;
                txtFile.Visible = false;
                btnFile.Visible = false;
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(capwebcam != null)
            {
                capwebcam.Dispose();
            }
        }
        private void btnFile_Click(object sender, EventArgs e)
        {
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                Image inputImage = Image.FromFile(ofdFile.FileName);
                txtFile.Text = ofdFile.FileName.ToString();
                               
            }
        }
        private void chbDrawCirclesOnOriginalImage_CheckedChanged(object sender, EventArgs e)
        {
            if(webCamCapturingInProcess == false)
            {
                ProcessImageAndUpdateGUI(new object(), new EventArgs());
            }
        }
        private void chbDrawLinesOnOriginalImage_CheckedChanged(object sender, EventArgs e)
        {
            if (webCamCapturingInProcess == false)
            {
                ProcessImageAndUpdateGUI(new object(), new EventArgs());
            }
        }
        private void chbDrawTrianglesAndPolygansOnOriginalImage_CheckedChanged(object sender, EventArgs e)
        {
            if (webCamCapturingInProcess == false)
            {
                ProcessImageAndUpdateGUI(new object(), new EventArgs());
            }
        }
        private void chbFillterOnColor_CheckedChanged(object sender, EventArgs e)
        {
            if(chbFillterOnColor.Checked == true)
            {
                lblBlue.Visible = true;
                lblGreen.Visible = true;
                lblRed.Visible = true;
                lblMin.Visible = true;
                lblMax.Visible = true;
                cmbMinBlue.Visible = true;
                cmbMinGreen.Visible = true;
                cmbMinRed.Visible = true;
                cmbMaxBlue.Visible = true;
                cmbMaxGreen.Visible = true;
                cmbMaxRed.Visible = true;
                lblGrayColorFilter.Text = "gray (color filtered):";
                ProcessImageAndUpdateGUI(new object(), new EventArgs());
            }
            else if (chbFillterOnColor.Checked == false)
            {
                lblBlue.Visible = false;
                lblGreen.Visible = false;
                lblRed.Visible = false;
                lblMin.Visible = false;
                lblMax.Visible = false;
                cmbMinBlue.Visible = false;
                cmbMinGreen.Visible = false;
                cmbMinRed.Visible = false;
                cmbMaxBlue.Visible = false;
                cmbMaxGreen.Visible = false;
                cmbMaxRed.Visible = false;
                lblGrayColorFilter.Text = "gray:";
                ProcessImageAndUpdateGUI(new object(), new EventArgs());
            }
        }
        private void txtFile_TextChanged(object sender, EventArgs e)
        {
            txtFile.SelectionStart = txtFile.Text.Length;
        }
        private void cmbMinBlue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(chbFillterOnColor.Checked == true && txtFile.Text != "")
            {
                
                dbMinBlue = Convert.ToDouble(cmbMinBlue.Text);
                ProcessImageAndUpdateGUI(new object(), new EventArgs());
            }
        }
        private void cmbMinGreen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chbFillterOnColor.Checked == true && txtFile.Text != "")
            {
                dbMinGreen = Convert.ToDouble(cmbMinGreen.Text);
                ProcessImageAndUpdateGUI(new object(), new EventArgs());
            }
            
        }
        private void cmbMinRed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chbFillterOnColor.Checked == true && txtFile.Text != "")
            {
                dbMinRed = Convert.ToDouble(cmbMinRed.Text);
                ProcessImageAndUpdateGUI(new object(), new EventArgs());
            }
            
        }
        private void cmbMaxBlue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chbFillterOnColor.Checked == true && txtFile.Text != "")
            {
                dbMaxBlue = Convert.ToDouble(cmbMaxBlue.Text);
                ProcessImageAndUpdateGUI(new object(), new EventArgs());
            }
        }
        private void cmbMaxGreen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chbFillterOnColor.Checked == true && txtFile.Text != "")
            {
                dbMaxGreen = Convert.ToDouble(cmbMaxGreen.Text);
                ProcessImageAndUpdateGUI(new object(), new EventArgs());
            }
        }
        private void cmbMaxRed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chbFillterOnColor.Checked == true && txtFile.Text != "")
            {
                dbMaxRed = Convert.ToDouble(cmbMaxRed.Text);
                ProcessImageAndUpdateGUI(new object(), new EventArgs());
            }
        }
        private void cmbMinBlue_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbMinBlue.Text) < 0 || Convert.ToInt32(cmbMinBlue.Text) > 255)
            {
                cmbMinBlue.Text = "0";
            }
            cmbMinBlue_SelectedIndexChanged(new object(), new EventArgs());
        }
        private void cmbMinGreen_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbMinGreen.Text) < 0 || Convert.ToInt32(cmbMinGreen.Text) > 255)
            {
                cmbMinGreen.Text = "0";
            }
            cmbMinGreen_SelectedIndexChanged(new object(), new EventArgs());
        }
        private void cmbMinRed_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbMinRed.Text) < 0 || Convert.ToInt32(cmbMinRed.Text) > 255)
            {
                cmbMinRed.Text = "0";
            }
            cmbMinRed_SelectedIndexChanged(new object(), new EventArgs());
        }
        private void cmbMaxBlue_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbMaxBlue.Text) < 1 || Convert.ToInt32(cmbMaxBlue.Text) > 256)
            {
                cmbMaxBlue.Text = "1";
            }
            cmbMaxBlue_SelectedIndexChanged(new object(), new EventArgs());
        }
        private void cmbMaxGreen_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbMaxGreen.Text) < 1 || Convert.ToInt32(cmbMaxGreen.Text) > 256)
            {
                cmbMaxGreen.Text = "1";
            }
            cmbMaxGreen_SelectedIndexChanged(new object(), new EventArgs());
        }
        private void cmbMaxRed_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbMaxRed.Text) < 1 || Convert.ToInt32(cmbMaxRed.Text) > 256)
            {
                cmbMaxRed.Text = "1";
            }
            cmbMaxRed_SelectedIndexChanged(new object(), new EventArgs());
        }
        private void cmbMinBlue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Return))
            {
                e.SuppressKeyPress = true;
                lblOriginal.Focus(); 
            }
        }
        private void cmbMinGreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Return))
            {
                e.SuppressKeyPress = true;
                lblOriginal.Focus();
            }
        }
        private void cmbMinRed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Return))
            {
                e.SuppressKeyPress = true;
                lblOriginal.Focus();
            }
        }
        private void cmbMaxBlue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Return))
            {
                e.SuppressKeyPress = true;
                lblOriginal.Focus();
            }
        }
        private void cmbMaxGreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Return))
            {
                e.SuppressKeyPress = true;
                lblOriginal.Focus();
            }
        }
        private void cmbMaxRed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Return))
            {
                e.SuppressKeyPress = true;
                lblOriginal.Focus();
            }
        }
        void ProcessImageAndUpdateGUI(object sender, EventArgs e)
        {
            if(radImageFile.Checked == true)
            {
                try
                {
                    imgOriginal = new Image<Bgr,Byte>(txtFile.Text);
                }
                catch (Exception ex)
                {
                    return;
                }
            }
            else if(radWebCam.Checked == true)
            {
                try
                {
                    imgOriginal = capwebcam.QueryFrame();
                }
                catch (Exception ex)
                {
                    return;
                }
            }
            if(imgOriginal == null)
            {
                return;
            }
            imgSmoothed = imgOriginal.PyrDown().PyrUp();
            imgSmoothed._SmoothGaussian(3);
            if(chbFillterOnColor.Checked == true)
            {
                imgGrayColorFiltered = imgSmoothed.InRange(new Bgr(dbMinBlue,dbMinGreen,dbMinRed),new Bgr(dbMaxBlue,dbMaxGreen,dbMaxRed));
                imgGrayColorFiltered = imgGrayColorFiltered.PyrDown().PyrUp();
                imgGrayColorFiltered._SmoothGaussian(3);
            }
            else if(chbFillterOnColor.Checked == false)
            {
                imgGrayColorFiltered = imgSmoothed.Convert<Gray, Byte>();
            }
            Gray grayCannyThreshold = new Gray(160);
            Gray grayCircleAccumThreshold = new Gray(100);
            Gray grayThreshLinking = new Gray(80);
            imgCanny = imgGrayColorFiltered.Canny(grayCannyThreshold, grayThreshLinking);
            imgCircles = imgOriginal.CopyBlank();
            imgLines = imgOriginal.CopyBlank();
            imgTrisRectsPolys = imgOriginal.CopyBlank();
            Double dblAccumRes = 2.0;
            Double dblMinDistBetweenCircles = imgGrayColorFiltered.Height / 4;
            int intMinRadius = 10;
            int intMaxRadius = 400;
            CircleF[] circles = imgGrayColorFiltered.HoughCircles(grayCannyThreshold, grayCircleAccumThreshold, dblAccumRes, dblMinDistBetweenCircles, intMinRadius, intMaxRadius)[0];
            foreach(CircleF circle in circles)
            {
                imgCircles.Draw(circle, new Bgr(Color.Red),2);
                if(chbDrawCirclesOnOriginalImage.Checked == true)
                {
                    imgCircles.Draw(circle, new Bgr(Color.Red), 2);
                }
            }
            Double dblRhoRes = 1.0;
            Double dblThetaRes = 4.0 *(Math.PI/180.0);
            int intThreshold = 20;
            Double dblMinLineWidth = 30.0;
            Double dblMinGapBetweenLines = 10.0;
            LineSegment2D[] lines = imgCanny.Clone().HoughLinesBinary(dblRhoRes, dblThetaRes, intThreshold, dblMinLineWidth, dblMinGapBetweenLines)[0];
            foreach(LineSegment2D line in lines)
            {
                imgLines.Draw(line, new Bgr(Color.DarkGreen),2);
                if(chbDrawLinesOnOriginalImage.Checked == true)
                {
                    imgOriginal.Draw(line, new Bgr(Color.DarkGreen),2);
                }
            }
            Contour<Point> contours = imgCanny.FindContours();
            List<Triangle2DF> lstTreangles = new List<Triangle2DF>();
            List<MCvBox2D> lstRectangles = new List<MCvBox2D>();
            List<Contour<Point>> lstPoluhons = new List<Contour<Point>>();
            while(contours != null)
            {
                Contour<Point> contour = contours.ApproxPoly(10.0);
                if(contour.Area > 250.0)
                {
                    if(contour.Total == 3)
                    {
                        Point[] ptPoints = contour.ToArray(); 
                        lstTreangles.Add(new Triangle2DF(ptPoints[0],ptPoints[1],ptPoints[2]));
                    }
                    else if(contour.Total >= 4 && contour.Total <= 6)
                    {
                        Point[] ptPoints = contour.ToArray(); 
                        Boolean blnIsRectangle = true;
                        if(contour.Total == 4)
                        {
                            LineSegment2D[] ls2dEdges = PointCollection.PolyLine(ptPoints, true);
                            for(int i = 0; i< ls2dEdges.Length -1; i++)
                            {
                                Double dblAngle = Math.Abs(ls2dEdges[(i+1) % ls2dEdges.Length].GetExteriorAngleDegree(ls2dEdges[i]));
                                if(dblAngle < 80.0 || dblAngle > 100.0)
                                {
                                    blnIsRectangle = false;
                                }
                            }
                        }
                        else
                        {
                            blnIsRectangle = false;
                        }
                        if(blnIsRectangle)
                        {
                            lstRectangles.Add(contour.GetMinAreaRect());
                        }
                        else
                        {
                            lstPoluhons.Add(contour);
                        }
                    }
                }
                
                contours = contours.HNext;
            }
            foreach(Triangle2DF triangle in lstTreangles)
            {
               imgTrisRectsPolys.Draw(triangle, new Bgr(Color.Yellow),2);
                if(chbDrawTrianglesAndPolygansOnOriginalImage.Checked == true)
                {
                    imgOriginal.Draw(triangle, new Bgr(Color.Yellow),2);
                }
            }
            foreach(MCvBox2D rect in lstRectangles)
            {
                imgTrisRectsPolys.Draw(rect, new Bgr(Color.Blue),2);
                if(chbDrawTrianglesAndPolygansOnOriginalImage.Checked == true)
                {
                    imgOriginal.Draw(rect, new Bgr(Color.Blue),2);
                }
            }
            foreach(Contour<Point> contPoly in lstPoluhons)
            {
                imgTrisRectsPolys.Draw(contPoly, new Bgr(Color.Gray),2);
                if(chbDrawTrianglesAndPolygansOnOriginalImage.Checked == true)
                {
                    imgOriginal.Draw(contPoly, new Bgr(Color.Gray),2);
                }
            }
            ibOriginal.Image = imgOriginal;
            ibGrayColorFilter.Image = imgGrayColorFiltered;
            ibCanny.Image = imgCanny;
            ibLines.Image = imgLines;
            ibTrianglesAndPolys.Image = imgTrisRectsPolys;
             
        }
        
      }
    }
