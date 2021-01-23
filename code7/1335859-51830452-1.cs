    // in your poco
    public string HeaderImage { get; set; } =
    	Path.GetDirectoryName(Path.GetDirectoryName(
    		System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName()
    			.CodeBase))) + "\\assets\\your_logo.png";
    		
    // then in your function
    myDoc.addImageReference(HeaderImage.Replace("file:\\", string.Empty), "Logo");
    		pdfPage.addImage(myDoc.getImageReference("Logo"), 13, 720, 60, 60);
