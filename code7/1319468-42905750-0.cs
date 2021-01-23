	var svgDoc = SvgDocument.Open(imagePath);
	using(var Image = new Bitmap(svgDoc.Draw()))
	{
	    Image.Save(context.Response.OutputStream, ImageFormat.Png);
	    context.Response.ContentType = "image/png";
	    context.Response.Cache.SetCacheability(HttpCacheability.Public);
	    context.Response.Cache.SetExpires(DateTime.Now.AddMonths(1));
	}
