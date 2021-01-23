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
    			string path = AppDomain.CurrentDomain.BaseDirectory; // You wont need it 
    			System.IO.File.Copy(imageFile.FileName, path); // Copy Needs Source File Name and Destination File Name
    		}
    	}
    }
