	private void Example(Pixbuf pb)
	{
		ImageSurface imgSurface = new ImageSurface(Format.RGB24, pb.Width, pb.Height);
		using (Cairo.Context cr = new Cairo.Context(imgSurface)) {
			Gdk.CairoHelper.SetSourcePixbuf (cr, pb, 0, 0);
			cr.Paint ();
			cr.Dispose ();
		}
	}
