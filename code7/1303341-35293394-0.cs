	void processFrameGUI(object sender,EventArgs srg)
	{
		img=capWebcam.QueryFrame();
		if(img==null) return;
		imgout=img.InRange(new Bgr(0,0,0),new Bgr(0,0,0));
		imgout=imgout.SmoothGaussian(9);
		if (toggle)
		{
          // Note the following line:
          hb.ClearHistogram();
		  hb.GenerateHistograms(img, 256);
		  hb.Refresh();// show 256 shades
		  hb.Enabled = true;
		 }
		ibOriginal.Image=img;
		ibProcessed.Image=imgout;
	 }
