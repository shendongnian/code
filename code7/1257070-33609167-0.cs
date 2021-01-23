	public TiffImageFormatter()
	{
		SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/tiff"));
		MediaTypeMappings.Add(
					new RequestHeaderMapping("Accept", "image\tiff", 
											  StringComparison.OrdinalIgnoreCase,
					                          false, "image\tiff"));
	}
	
