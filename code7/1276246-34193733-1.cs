	// ...
	image.Name = "Image" + i;
	this.RegisterName(image.Name, image);
	
	// ...
	
	for (int i = 1; i < itotal; i++)
    {
        Binding binding = new Binding
        {
            Source = AtextBox,
            Path = new PropertyPath("Text"),
        };
        Image imagex = (Image)this.FindName("Image" + i);
        xImage = imagex;
        xImage.SetBinding(ContentControl.OpacityProperty, binding);
    }
