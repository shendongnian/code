    public ActionResult GenerateImage(string savingAmount, string savingDest)
    {
        // Hardcoding values for testing purposes.
        savingAmount = "25,000.00";
        savingDest = "Canada";
        PointF firstLocation = new PointF(10f, 10f);
        PointF secondLocation = new PointF(10f, 50f);
        Image imgBackground = Image.FromFile(Server.MapPath("~/assets/img/fb-share.jpg"));
        using (Graphics graphics = Graphics.FromImage(imgBackground))
        {
            using (Font arialFont = new Font("Arial", 10))
            {
                graphics.DrawString(savingAmount, arialFont, Brushes.White, firstLocation);
                graphics.DrawString(savingDest, arialFont, Brushes.White, secondLocation);
            }
        }
        imgBackground.Save(Response.OutputStream, ImageFormat.Png);
        Response.ContentType = "image/png";
        Response.Flush();
        Response.End();
        return null;
    }
