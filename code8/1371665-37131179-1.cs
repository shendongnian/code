    public partial class DisplayImagePage:Page
    {
        public void ibDisplayImg_click(object sender,EventArgs e)
        {
            // read image bytes from database
            Byte[] i= ReadImageFromDatabase();
            img.Src = i.ConvertToBase64ImageFormat(  ImageFormats.Png);
        }
    }
