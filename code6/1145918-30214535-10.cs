    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Drawing;
    using System.Drawing.Imaging;
    using ScreenCaptureDemo;
    using System.Windows.Forms;
    
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void btnCapture_Click(object sender, EventArgs e)
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                bitmap.Save(Server.MapPath("~/Content/test.jpg"), ImageFormat.Jpeg); //Change Content to any folder name you desire
            }
        }
    }
