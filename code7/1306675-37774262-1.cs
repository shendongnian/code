    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing.Imaging;
    using System.Drawing.Drawing2D;
    
    
    namespace TESTSCAN
    {
        public partial class Form1 : Form
        {
            int cropX, cropY, cropWidth, cropHeight;
            //here rectangle border pen color=red and size=2;
            Pen borderpen = new Pen(Color.Red, 2);
            Image _orgImage;
            Bitmap crop;
            List<string> devices;
            //fill the rectangle color =white
            SolidBrush rectbrush = new SolidBrush(Color.FromArgb(100, Color.White));
            int pages;
            int currentPage = 0;
            public Form1()
            {
                InitializeComponent();
                IsSaved = false;
            }
            List<Image> images;
            private string f_path;
            private string doc_no;
            private bool savedOrNot = false;
            private List<string> fNames;
            public List<string> fileNames
            {
                get { return fNames; }
                set { fNames = value; }
            }
            public String SavePath
            {
                get { return f_path; }
                set { f_path = value; }
            }
            public String DocNo
            {
                get { return doc_no; }
                set { doc_no = value; }
            }
            public bool IsSaved
            {
                get { return savedOrNot; }
                set { savedOrNot = value; }
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                lblPath.Text = SavePath;
                lblDocNo.Text = DocNo;
    
                //get list of devices available
                devices = WIAScanner.GetDevices();
    
                foreach (string device in devices)
                {
                    lbDevices.Items.Add(device);
                }
                //check if device is not available
                if (lbDevices.Items.Count != 0)
                {
                    lbDevices.SelectedIndex = 0;
    
                }
            }
    
            private void btnPreview_Click(object sender, EventArgs e)
            {
                try
                {
                    //get list of devices available
    
                    if (lbDevices.Items.Count == 0)
                    {
                        MessageBox.Show("You do not have any WIA devices.");
    
                    }
                    else
                    {
                        //get images from scanner
                        pages =3;
                        images = WIAScanner.Scan((string)lbDevices.SelectedItem, pages);
                        pages = images.Count;
                        if (images != null)
                        {
                            foreach (Image image in images)
                            {
                                pic_scan.Image = images[0];
                                pic_scan.Show();
                                pic_scan.SizeMode = PictureBoxSizeMode.StretchImage;
                                _orgImage = images[0];
                                crop = new Bitmap(images[0]);
                                btnOriginal.Enabled = true;
                                btnSave.Enabled = true;
                                currentPage = 0;
                                //pic_scan.Image = image;
                                //pic_scan.Show();
                                //pic_scan.SizeMode = PictureBoxSizeMode.StretchImage;
                                //_orgImage = image;
                                //crop = new Bitmap(image);
                                //btnOriginal.Enabled = true;
                                //btnSave.Enabled = true;
                            }
                        }
                    }
    
    
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
                
            }
    
           
            List<string> sss = new List<string>();
            private void btnSave_Click(object sender, EventArgs e)
            {
                try
                {
                    if (crop != null)
                    {
                        SavePath = @"D:\NAJEEB\scanned images\";
                        DocNo = "4444";
                        string currentFName = DocNo + Convert.ToString(currentPage + 1) + ".jpeg";
                        crop.Save(SavePath + currentFName, ImageFormat.Jpeg);
                        sss.Add(currentFName);
                        MessageBox.Show("Document Saved Successfully");
                        IsSaved = true;
                        currentPage += 1;
                        if (currentPage < (pages))
                        {
                            pic_scan.Image = images[currentPage];
                            pic_scan.Show();
                            pic_scan.SizeMode = PictureBoxSizeMode.StretchImage;
                            _orgImage = images[currentPage];
                            crop = new Bitmap(images[currentPage]);
                            btnOriginal.Enabled = true;
                            btnSave.Enabled = true;
    
                        }
                        else
                        { btnSave.Enabled =false;
                        fileNames = sss;
                        }
                    }
                 
                }
                catch (Exception exc)
                {
                    IsSaved = false;
                    MessageBox.Show(exc.Message);
                }
            }
    
            private void btnOriginal_Click(object sender, EventArgs e)
            {
                if (_orgImage != null)
                {
                    crop = new Bitmap(_orgImage);
                    pic_scan.Image = _orgImage;
                    pic_scan.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic_scan.Refresh();
                }
            }
    
            private void pic_scan_MouseDown(object sender, MouseEventArgs e)
            {
                try
                {
                    if (e.Button == MouseButtons.Left)//here i have use mouse click left button only
                    {
                        pic_scan.Refresh();
                        cropX = e.X;
                        cropY = e.Y;
                        Cursor = Cursors.Cross;
                    }
                    pic_scan.Refresh();
                }
                catch { }
            }
    
            private void pic_scan_MouseMove(object sender, MouseEventArgs e)
            {
                try
                {
                    if (pic_scan.Image == null)
                        return;
    
                    if (e.Button == MouseButtons.Left)//here i have use mouse click left button only
                    {
                        pic_scan.Refresh();
                        cropWidth = e.X - cropX;
                        cropHeight = e.Y - cropY;
                    }
                    pic_scan.Refresh();
                }
                catch { }
            }
    
            private void pic_scan_MouseUp(object sender, MouseEventArgs e)
            {
                try
                {
                    Cursor = Cursors.Default;
                    if (cropWidth < 1)
                    {
                        return;
                    }
                    Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                    Bitmap bit = new Bitmap(pic_scan.Image, pic_scan.Width, pic_scan.Height);
                    crop = new Bitmap(cropWidth, cropHeight);
                    Graphics gfx = Graphics.FromImage(crop);
                    gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;//here add  System.Drawing.Drawing2D namespace;
                    gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;//here add  System.Drawing.Drawing2D namespace;
                    gfx.CompositingQuality = CompositingQuality.HighQuality;//here add  System.Drawing.Drawing2D namespace;
                    gfx.DrawImage(bit, 0, 0, rect, GraphicsUnit.Pixel);
                   
                }
                catch { }
            }
    
            private void pic_scan_Paint(object sender, PaintEventArgs e)
            {
                Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                Graphics gfx = e.Graphics;
                gfx.DrawRectangle(borderpen, rect);
                gfx.FillRectangle(rectbrush, rect);
            }
        }
    }
