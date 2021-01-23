     using System.Drawing;
     protected void btnSave_Click(object sender, EventArgs e)
     {
        if (fup2.HasFile)
        {
            Regex reg = new Regex(@"(?i).*\.(gif|jpe?g|png|tif)$");
            string uFile = fup2.FileName;
            if (reg.IsMatch(uFile))
            {
                string saveDir = Server.MapPath(@"~/Images/");
                string SavePath = saveDir + Path.GetFileName(uFile) + ".png";
                Bitmap b = (Bitmap)Bitmap.FromStream(fup2.InputStream);
                b.Save(SavePath, ImageFormat.Png);
            }
            else
            {
                Response.Write("Error");
            }
        }
    }
