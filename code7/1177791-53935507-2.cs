    public void Test1()
    {
    	var controller = new Mock<MyContoller>();
    	controller.Setup(x => x.Upload).Returns(new CustomResponse());
    
    	controller.Request = new HttpRequestMessage();
    	controller.Request.Content = new StreamContent(GetContent());
    	controller.PostedFile = GetPostedFile();
    
    	var result = controller.Upload().Result;
    }
    
    private HttpPostedFileBase GetPostedFile()
    {
    	var postedFile = new Mock<HttpPostedFileBase>();
    	using (var stream = new MemoryStream())
    	using (var bmp = new Bitmap(1, 1))
    	{
    		var graphics = Graphics.FromImage(bmp);
    		graphics.FillRectangle(Brushes.Black, 0, 0, 1, 1);
    		bmp.Save(stream, ImageFormat.Jpeg);
    		postedFile.Setup(pf => pf.InputStream).Returns(stream);
    		postedFile.Setup(pf => pf.ContentLength).Returns(1024);
    		postedFile.Setup(pf => pf.ContentType).Returns("bmp");
    	}
    	return postedFile.Object;
    }
