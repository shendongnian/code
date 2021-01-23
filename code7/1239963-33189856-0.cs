    private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
      //Create a bitmap in a fixed ratio to the original drawing area.
      Bitmap bm=new Bitmap(this.ClientSize.Width/5, this.ClientSize.Height/5);
      //Create a GraphicsPath object. 
      GraphicsPath pth=new GraphicsPath();
      //Add the string in the chosen style. 
      pth.AddString("Text Halo",new FontFamily("Verdana"),(int)FontStyle.Regular,100,new Point(20,20),StringFormat.GenericTypographic);
      //Get the graphics object for the image. 
      Graphics g=Graphics.FromImage(bm);
      //Create a matrix that shrinks the drawing output by the fixed ratio. 
      Matrix mx=new Matrix(1.0f/5,0,0,1.0f/5,-(1.0f/5),-(1.0f/5));
      //Choose an appropriate smoothing mode for the halo. 
      g.SmoothingMode=SmoothingMode.AntiAlias;
      //Transform the graphics object so that the same half may be used for both halo and text output. 
      g.Transform=mx;
      //Using a suitable pen...
      Pen p=new Pen(Color.Yellow,3);
      //Draw around the outline of the path
      g.DrawPath(p,pth);
      //and then fill in for good measure. 
      g.FillPath(Brushes.Yellow,pth);
      //We no longer need this graphics object
      g.Dispose();
      //this just shifts the effect a little bit so that the edge isn't cut off in the demonstration
      e.Graphics.Transform=new Matrix(1,0,0,1,50,50);
      //setup the smoothing mode for path drawing
      e.Graphics.SmoothingMode=SmoothingMode.AntiAlias;
      //and the interpolation mode for the expansion of the halo bitmap
      e.Graphics.InterpolationMode=InterpolationMode.HighQualityBicubic;
      //expand the halo making the edges nice and fuzzy. 
      e.Graphics.DrawImage(bm,ClientRectangle,0,0,bm.Width,bm.Height,GraphicsUnit.Pixel);
      //Redraw the original text
      e.Graphics.FillPath(Brushes.Black,pth);
      //and you're done. 
      pth.Dispose();
    }
