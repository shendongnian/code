    private void button1_Click(object sender,EventArgs e)
    {
        Bitmap bmp=null; 
        using(Image img =Image.FromFile(@"filelocation.tif")
        {
            bmp=new Bitmap(img);
            bmp.MakeTransparent();
            for(int y=0;y<bmp.Height;y++)
            {
                for(int x=0; x<bmp.Width;x++)
                {
                    if(bmp.GetPixel(x,y).A!=255)
                    {
                        bmp.SetPixel(x,y,Color.Black);
                    }
                }   
            }
        }
    }
    bmp.save(@"new file location ");
