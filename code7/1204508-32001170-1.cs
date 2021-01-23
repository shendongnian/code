    private void btnImageUpload_Click(object sender, RoutedEventArgs e)
    {
    	OpenFileDialog imageFile = new OpenFileDialog();
    	imageFile.InitialDirectory = @"C:\";
    	imageFile.Filter = "Image Files (*.jpg)|*.jpg|All Files(*.*)|*.*";
    	imageFile.FilterIndex = 1;
    
    	if (imageFile.ShowDialog() == true)
    	{
    		if(imageFile.CheckFileExists)
    		{
    			System.IO.File.Copy(imageFile.FileName, SomeName + ".jpg"); // SomeName Must change everytime like ID or something 
    		}
    	}
    }
