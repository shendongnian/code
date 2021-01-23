    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace HCRLibrarytest
    {
        public partial class MainForm : Form
        {
            public Point startingPoint = Point.Empty;
            public Point movingPoint = Point.Empty;
            public bool panning = false;
            Image _OrginalBitmap;
            public static Image _NewBitmap;
            public bool IsSelecting = false;
            public int X0, Y0, X1, Y1;
    
            public MainForm()
            {
                InitializeComponent();
            }
    
            public void btn_openimage_Click(object sender, EventArgs e)
            {
                OpenFileDialog dialog2 = new OpenFileDialog
                {
                    Filter = "Bitmap Image (*.jpeg)|*.jpeg"
                };
    
                using (OpenFileDialog dialog = dialog2)
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (StreamReader reader = new StreamReader(dialog.FileName))
                            {
                                this._OrginalBitmap = new Bitmap(dialog.FileName);
                                this.pb_fullimage.Image = this._OrginalBitmap;
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.ToString());
                        }
                    }
                }
            }
    
            public void pb_fullimage_MouseUp(object sender, MouseEventArgs e)
            {
                if (pb_fullimage.Image != null)
                {
                    if (!checkBox1.Checked)
                    {
                        panning = false;
                    }
    
                    else
                    {
                        if (!IsSelecting) return;
                        IsSelecting = false;
                        pb_fullimage.Image = _NewBitmap;
                        int wid = Math.Abs(X0 - X1);
                        int hgt = Math.Abs(Y0 - Y1);
                        if ((wid < 1) || (hgt < 1)) return;
                        Bitmap area = new Bitmap(wid, hgt);
                        using (Graphics gr = Graphics.FromImage(area))
                        {
                            Rectangle source_rectangle = new Rectangle(Math.Min(X0, X1), Math.Min(Y0, Y1), wid, hgt);
                            Rectangle dest_rectangle = new Rectangle(0, 0, wid, hgt);
                            gr.DrawImage(_NewBitmap, dest_rectangle, source_rectangle, GraphicsUnit.Pixel);
                        }
                        pb_selectedportion.Image = area;
                    }
                }
            }
    
            public void pb_fullimage_MouseDown(object sender, MouseEventArgs e)
            {
                if (pb_fullimage.Image != null)
                {
                    if (!checkBox1.Checked)
                    {
                        panning = true;
                        startingPoint = new Point(e.Location.X - movingPoint.X, e.Location.Y - movingPoint.Y);
                    }
                    else
                    {
                        IsSelecting = true;
                        X0 = e.X;
                        Y0 = e.Y;
                    }
                }
            }
    
            public void pb_fullimage_MouseMove(object sender, MouseEventArgs e)
            {
                if (pb_fullimage.Image != null)
                {
                    if (!checkBox1.Checked)
                    {
                        if (panning)
                        {
                            movingPoint = new Point(e.Location.X - startingPoint.X, e.Location.Y - startingPoint.Y);
                            pb_fullimage.Invalidate();
                            using (Bitmap bitmap = new Bitmap(pb_fullimage.ClientSize.Width, pb_fullimage.ClientSize.Height))
                            {
                                pb_fullimage.DrawToBitmap(bitmap, pb_fullimage.ClientRectangle);
                                try { bitmap.Save(AppDomain.CurrentDomain.BaseDirectory + "draw.jpg"); }
                                catch (Exception ex) { Console.Write(ex.ToString()); }
                            }
                        }
                    }
    
                    else
                    {
                        if (!IsSelecting) return;
                        X1 = e.X;
                        Y1 = e.Y;
                        Bitmap bm = new Bitmap(Bitmap.FromStream(File.OpenRead(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "draw.jpg"))));
                        using (Graphics gr = Graphics.FromImage(bm))
                        {
                            gr.DrawRectangle(Pens.WhiteSmoke, Math.Min(X0, X1), Math.Min(Y0, Y1), Math.Abs(X0 - X1), Math.Abs(Y0 - Y1));
                        }
                        _NewBitmap = bm;
                    }
                }
            }
    
            public void pb_fullimage_Paint(object sender, PaintEventArgs e)
            {
                if (pb_fullimage.Image != null && !checkBox1.Checked)
                {
                    e.Graphics.Clear(Color.White);
                    e.Graphics.DrawImage(pb_fullimage.Image, movingPoint);
                }
            }
        }
    }
