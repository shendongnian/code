    List<string> lstNameImage = new List<string>();
    //List<string> lstAliasImage = new List<string>(); <-- no need anymore
    for (int i = 0; i < lstNameImage.Count; i++)
    {
        string newFile = Path.GetDirectoryName(lstNameImage[i]) + "\\" + name + " " + i;
        File.Move(lstNameImage[i], newFile);
        lstNameImage[i] = newFile;
    }
    
    for (int i = 0; i < lstImgAdded.Items.Count; i++)
    {
        string imgPath = lstImgAdded.Items[i].Text;
        lstNameImage.Add(imgPath);
    }
    //foreach (var alias in lstAliasImage) <-- also no need anymore
    //{
        foreach (var items in lstNameImage)
        {
            Image img = Image.FromFile(items);
            Graphics g = Graphics.FromImage(img);
            g.DrawImage(DrawText(alias, new Font(cbxFont.Text, fontSize), colorInput, Color.Transparent), new Point(350, 160));
            g.Dispose();
            ScaleImage(img, witdhImg, heightImg).Save(@"img\hinhmau\" + alias + "." + cbxImgType.Text, ImageFormat.Jpeg);
            picPreview.Image = img;
            picPreview.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    //}
