	protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
	{
		base.OnElementPropertyChanged(sender, e);
		if (e.PropertyName == "SvgPath")
		{
			var svgStream = _formsControl.SvgAssembly.GetManifestResourceStream(_formsControl.SvgPath);
			var reader = new SvgReader(new StreamReader(svgStream), new StylesParser(new ValuesParser()), new ValuesParser());
			var graphics = reader.Graphic;
			var canvas = new ApplePlatform().CreateImageCanvas(graphics.Size);
			graphics.Draw(canvas);
			var image = canvas.GetImage();
			var uiImage = image.GetUIImage();
			Control.Image = uiImage;
		}
	}
